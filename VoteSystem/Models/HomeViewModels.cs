using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VoteSystem.Models
{
    //Home控制器的视图模型
    public class IndexModel {
        public String title { get; set; }//标题
        public List<Tag> select_tags { get; set; }//选择的标签
        public List<Tag> tags { get; set; }//显示的标签
        public List<Type>  select_types { get; set; }//选择的类型
        public List<Type> types { get; set; }//显示的类型
        public int sortby { get; set; }//排序方式
        public List<Question> questions { get; set; }//显示的问题
    }
    public class publishModel {
        [Required]
        [StringLength(200)]
        [Display(Name ="标题")]
        public String title { get; set; }
        [Required]
        [Display(Name ="类型")]
        public Type typeID { get; set; }
        [Required]
        [Display(Name ="标签")]
        public Tag tagID { get; set; }
        [Required]
        public User userID { get; set; }
        public DateTime postTime { get; set; }
        [Required]
        [Display(Name ="结束时间")]
        public DateTime endTime { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name ="问题描述")]
        public String queDes { get; set; }
        [Required]
        [Display(Name ="选项数目")]
        public int optionNum { get; set; }
        [Required]
        public List<String> options { get; set; }
    }
}