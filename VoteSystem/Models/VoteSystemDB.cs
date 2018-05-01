using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;

namespace VoteSystem.Models
{
    public class VoteSystemDB:DbContext
    {
        public VoteSystemDB() : base("name=VoteSystemDB") {

        }
        public DbSet<User> users { get; set; }//用户
        public DbSet<Question> questions { get; set; }//问题
        public DbSet<Vote> votes { get; set; }//投票
        public DbSet<Upvote> upvotes { get; set; }//点赞
        public DbSet<Type> types { get; set; }//类型
    }
    //保证数据库上下文对象唯一
    public class DBContextFactory
    {
        public static DbContext GetCurrentContext()
        {
            //CallContext:保证线程内创建的数据操作上下文是唯一的。
            DbContext DbContext = (DbContext)CallContext.GetData("context");
            if (DbContext == null)
            {
                DbContext = new VoteSystemDB();
                CallContext.SetData("context", DbContext);
            }
            return DbContext;
        }
    }
}