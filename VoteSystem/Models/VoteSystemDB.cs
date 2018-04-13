using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class VoteSystemDB:DbContext
    {
        public VoteSystemDB() : base("name=VoteSystemDB") {}
        public DbSet<User> users { get; set; }//用户
        public DbSet<Question> questions { get; set; }//问题
        public DbSet<Vote> votes { get; set; }//投票
        public DbSet<Upvote> upvotes { get; set; }//点赞
        public DbSet<Tag> tags { get; set; }//标签
        public DbSet<Type> types { get; set; }//类型
    }
}