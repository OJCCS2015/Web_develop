using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VoteSystem.Models;

namespace VoteSystem.Dao
{
    public class UpVoteDao
    {
        private VoteSystemDB db = new VoteSystemDB();
        //添加点赞
        public void add(Upvote upvote) {
            db.upvotes.Add(upvote);
            db.SaveChanges();
        }
        //获取指定id的点赞
        public Upvote getById(int id) {
            Upvote upvote = db.upvotes.Where(u => u.ID == id).FirstOrDefault();
            return upvote;
        }
        //获取指定点赞用户的点赞集合
        public List<Upvote> getByVoteUser(User user) {
            List<Upvote> list = db.upvotes.Where(u => u.voteUserID == user).ToList();
            return list;
        }
        //获取指定被点赞用户的点赞统计
        public int getCount(User user) {
            int count = db.upvotes.Where(u => u.zambiaUserID == user).Count();
            return count;
        }
    }
}