using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class User
    {
        public int ID { get; set; }     //用户id
        public String userNick { set; get; }//用户昵称
        public String userEmail { get; set; }//邮箱
        public String userPsw { get; set; }//用户密码
        public String userDes { get; set; }//用户介绍
        public int pridectNum { get; set; }//用户预测题目数
        public int postNum { get; set; }//用户发布题目数
        public double middleNum { get; set; }//中位数
        public double brierNum { get; set; }//布雷尔分数
        public int rightNum { get; set; }//预测正确数
        public int upvoteNum { get; set; }//收到赞数
    }
}