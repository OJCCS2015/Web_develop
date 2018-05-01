using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class QuestionDao
    {
        private VoteSystemDB db = (VoteSystemDB)DBContextFactory.GetCurrentContext();
        //保存问题
        public void add(Question q) {
            db.questions.Add(q);
            db.SaveChanges();
        }
        //修改问题
        public void update(Question q) {
            db.questions.Attach(q);
            db.Entry(q).State = EntityState.Modified;
            db.SaveChanges();
        }
        //按名称搜索
        public List<Question> search_title(String title) {
            List<Question> questions = db.questions.Where(q => q.title.Contains(title)).ToList();
            return questions;
        }
        //通过id获取指定问题
        public Question getById(int id) {
            Question question = db.questions.Where(q => q.ID == id).FirstOrDefault();
            return question;
        }
        //获取指定用户的问题集合
        public List<Question> getByUser(User user) {
            List<Question> list = db.questions.Where(q => q.userID.ID == user.ID).ToList();
            return list;
        }
        //获取指定数目的问题
        public List<Question> getAll(int start, int size) {
            return db.questions.OrderBy(q => q.ID).Skip(start).Take(size).ToList();
        }
        //获取指定类型和数目的问题集合
        public List<Question> getAll(Models.Type t,int start, int size) {
            List<Question> questions = db.questions.Where(q => q.typeID.ID == t.ID).ToList();
            return questions.OrderBy(q=>q.ID).Skip(start).Take(size).ToList();
        }
        //获取投票人数
        public int getVoteCount(Question q) {
            VoteDao votedao = new VoteDao();
            List<Vote> votelist = votedao.getByQuestion(q);
            QuestionDao questiondao = new Dao.QuestionDao();
            q.voteCount = votelist.Count;
            questiondao.update(q);
            return q.voteCount;
        }
        //获取统计结果
        public String getOptionData(Question q) {
            String optionData = null;
            VoteDao votedao = new VoteDao();
            List<Vote> votelist=votedao.getByQuestion(q);
       
            if (q.optionNum == 1)
            {
                if (votelist.Count != 0)
                {
                    int sum = 0;
                    foreach (Vote v in votelist)
                    {
                        sum+= int.Parse(v.voteRecord);
                    }
                    optionData = (sum / votelist.Count).ToString();//取投票结果的平均值
                }
                else
                {
                    optionData = 0.ToString();//没有投票记录时结果为0
                }
                   
            }
            else
            {
                //多选 [{'value':50,'name':'直接访问'},{'value':50,'name':'邮件营销'},{'value':50,'name':'联盟广告'},{'value':50,'name':'视频广告'},{'value':50,'name':'搜索引擎'}]
                JArray jarry = new JArray();
                String[] names = q.queOption.Split('#');
                int[] values = null;
                foreach (Vote v in votelist) {
                    String[] records=v.voteRecord.Split('#');
                    int[] sum = new int[records.Length-1];
                    //统计每个选项的总分
                    for (int i = 0; i < records.Length-1; i++) {
                        sum[i] += int.Parse(records[i]);
                    }
                    //计算平均分
                    for (int i = 0; i < sum.Length; i++) {
                        sum[i] /= votelist.Count;
                    }
                    values = sum;
                }
                if(values==null)
                    values= new int[q.optionNum];
                //组装
                for (int i = 0; i < names.Length-1; i++) {
                    JObject json = new JObject();
                    json["name"] = names[i];
                    json["value"] = values[i];
                    jarry.Add(json);
                }
                optionData = jarry.ToString();
            }
            QuestionDao questiondao = new Dao.QuestionDao();
            q.optionData = optionData;
            questiondao.update(q);

            return q.optionData;
        }
    }
}