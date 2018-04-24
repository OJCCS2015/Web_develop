using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class VoteDao
    {
        private VoteSystemDB db = new VoteSystemDB();
        //保存投票
        public void add(Vote v) {
            db.votes.Add(v);
            db.SaveChanges();
        }
        //获取指定id的投票信息
        public Vote getById(int id) {
            Vote vote = db.votes.Where(v => v.ID == id).FirstOrDefault();
            return vote;
        }
    }
}