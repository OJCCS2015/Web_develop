using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VoteSystem.Models
{
    //Account控制器的视图模型
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "邮箱")]
        public String userEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name = "密码")]
        public String userPsw { get; set; }
    }
    public class RegisterModel {
        [Required]
        [StringLength(16,MinimumLength =2)]
        [Display(Name ="昵称")]
        public String userNick { get; set; }
        [Required]
        [EmailAddress]

        [Display(Name ="邮箱")]
        public String userEmail { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16,MinimumLength =8)]
        [Display(Name ="密码")]
        public String userPsw { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("userPsw", ErrorMessage = "密码和确认密码不匹配。")]
        [Display(Name ="确认密码")]
        public String userPswRe { get; set; }
    }
    public class ReSetModel {
        [Required]
        public int ID { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name ="旧密码")]
        public String userPswOld { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name ="新密码")]
        public String userPswNew { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8)]
        [Display(Name ="确认密码")]
        [Compare("userPswNew",ErrorMessage = "密码和确认密码不匹配")]
        public String userPswRe { get; set; }
    }
    public class InfoModel {
        [Required]
        public int ID { get; set; }
        [Required]
        [StringLength(16, MinimumLength = 2)]
        [Display(Name = "用户昵称")]
        public String userNick { get; set; }
        [Required]
        [StringLength(500)]
        [Display(Name = "用户介绍")]
        public String userDes { get; set; }
        [Required]
        [Display(Name = "用户预测题目数")]
        public int pridectNum { get; set; }
        [Required]
        [Display(Name = "用户发布题目数")]
        public int postNum { get; set; }
        [Required]
        [Display(Name = "中位数")]
        public double middleNum { get; set; }
        [Required]
        [Display(Name = "布雷尔分数")]
        public double brierNum { get; set; }
        [Required]
        [Display(Name = "预测正确数")]
        public int rightNum { get; set; }
        [Required]
        [Display(Name = "收到赞数")]
        public int upvoteNum { get; set; }
    }
}