using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class QuestionDao
    {
        private VoteSystemDB db = new VoteSystemDB();
        //保存问题
        public void add(Question q) {
            db.questions.Add(q);
            db.SaveChanges();
        }
        //通过id获取指定问题
        public Question getById(int id) {
            Question question = db.questions.Where(q => q.ID == id).FirstOrDefault();
            return question;
        }
        //获取指定类型的问题集合
        public List<Question> getByType(Models.Type t,int start, int size) {
            List<Question> questions = db.questions.Where(q => q.typeID == t).ToList();
            
            return questions.OrderBy(q=>q.ID).Skip(start).Take(size).ToList();
        }

    }
}