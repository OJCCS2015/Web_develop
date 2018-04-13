using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Vote
    {
        public int ID { get; set; }//投票ID
        public Question queID { get; set; }//问题ID 外键
        public User userID { get; set; }//用户ID 外键
        public String voteComment { get; set; }//投票评论
        public String voteRecord { get; set; }//投票情况记录
    }
}