using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    public class Vote
    {
        public int ID { get; set; }//投票ID
        public virtual Question queID { get; set; }//问题ID 外键
        public virtual User userID { get; set; }//用户ID 外键
        public String voteComment { get; set; }//投票评论
        public String voteRecord { get; set; }//投票情况记录  
        //单选 0-100
        //多选 [{'value':50,'name':'直接访问'},{'value':50,'name':'邮件营销'},{'value':50,'name':'联盟广告'},{'value':50,'name':'视频广告'},{'value':50,'name':'搜索引擎'}]
        public DateTime voteTime { get; set; }//投票时间
    }
}