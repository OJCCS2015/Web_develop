using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoteSystem.Models
{
    //Home控制器的视图模型
    public class IndexModel {
        public String title { get; set; }//标题
        public List<Type>  select_types { get; set; }//选择的类型
        public List<Type> types { get; set; }//显示的类型
        public int sortby { get; set; }//排序方式
        public List<Question> questions { get; set; }//显示的问题
    }
    //发布页模型
    public class publishModel {
        [Required]
        public int userID { get; set; }
        [Required]
        [StringLength(200)]
        [Display(Name ="标题")]
        public String title { get; set; }
        [Required]
        [Display(Name ="类型")]
        public int typeID { get; set; }
        public List<SelectListItem> types { get; set; }
        [Required]
        [Display(Name ="标签")]
        public String tags { get; set; }
        [Required]
        [Display(Name = "开始时间")]
        public DateTime postTime { get; set; }
        [Required]
        [Display(Name ="结束时间")]
        public DateTime endTime { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name ="问题描述")]
        public String queDes { get; set; }
        [Required]
        [Range(1,8)]
        [Display(Name ="选项数目(1-8)")]
        public int optionNum { get; set; }
        [Required]
        [Display(Name ="可能答案")]
        public String options { get; set; }
    }
    //我的发布页模型
    public class MyPublishModel {
        public int userid { get; set; }
        public List<Question> questions { get; set; }
        public List<Type> types { get; set; }
        public int sortType { get; set; }
    }
    //我的投票页模型
    public class MyVoteModel
    {
        public int userid { get; set; }
        public List<Type> types { get; set; }
        public List<Question> questions { get; set; }
        public int sortType { get; set; }
    }
    //投票模型
    public class VoteModel {
        [Required]
        public int userID { get; set; }
        [Required]
        public int questionID { get; set; }
        public String title { get; set; }
        public String postTime { get; set; }
        public String endTime { get; set; }
        public String queDes { get; set; }
        public int optionNum { get; set; }
        public String[] options { get; set; }
        [Required]
        public String voteRecord { get; set; }
        [StringLength(500)]
        [Display(Name ="用户评论")]
        public String voteComment { get; set; }
        public String[] tags { get; set; }
        [Display(Name ="评论")]
        public List<Vote> votes { get; set; }
    }
    //搜索模型
    public class SearchModel {
        public string search_content { get; set; }
        public int current_page { get; set; }
        public int total { get; set; }
        public List<Question> questions { get; set; }
    }
}