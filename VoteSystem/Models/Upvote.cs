﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Upvote
    {
        public int ID { get; set; }//点赞ID
        public virtual User voteUserID { get; set; }//点赞用户ID 外键
        public virtual User zambiaUserID { get; set; }//被点赞用户ID 外键
        public DateTime upvoteTime { get; set; }//点赞时间
    }
}