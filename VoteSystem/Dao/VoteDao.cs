using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class VoteDao
    {
        private VoteSystemDB db = (VoteSystemDB)DBContextFactory.GetCurrentContext();
        //保存投票
        public void add(Vote v) {
            db.votes.Add(v);
            db.SaveChanges();
        }
        //修改投票
        public void update(Vote v) {
            db.votes.Attach(v);
            db.Entry(v).State= EntityState.Modified;
            db.SaveChanges();
        }
        //获取指定id的投票信息
        public Vote getById(int id) {
            Vote vote = db.votes.Where(v => v.ID == id).FirstOrDefault();
            return vote;
        }
        //获取指定用户的投票信息集合
        public List<Vote> getByUser(User user) {
            List<Vote> list = db.votes.Where(v => v.userID.ID == user.ID).ToList();
            return list;
        }
        //获取指定问题id的投票信息集合
        public List<Vote> getByQuestion(Question q) {
            List<Vote> list = db.votes.Where(v => v.queID.ID == q.ID).ToList();
            return list;
        }
        //获取指定问题id和用户id的投票记录
        public Vote getByUserAndQuestion(User u, Question q) {
            Vote res = db.votes.Where(v => v.queID.ID == q.ID && v.userID.ID==u.ID).FirstOrDefault();
            return res;
        }
    }
}