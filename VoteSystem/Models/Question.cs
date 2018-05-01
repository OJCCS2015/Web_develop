using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Question
    {
        public int ID { get; set; }//问题ID
        public Type typeID { get; set; }//问题类型 外键
        public String title { get; set; }//标题
        public String tags { get; set; }//标签
        public User userID { get; set; }//发布用户ID 外键
        public DateTime postTime { get; set; }//发布时间
        public DateTime endTime { get; set; }//结束时间
        public String queDes { get; set; }//问题描述
        public String queOption { get; set; }//问题选项
        public int optionNum { get; set; }//问题选项数目
        public int voteCount { get; set; }//投票人数
        public String optionData { get; set; }//问题选项的数据
        public String queStatus { get; set; }//问题状态
        public double brierNum { get; set; }//布雷尔分数
        public double middleNum { get; set; }//中位数

    }
}