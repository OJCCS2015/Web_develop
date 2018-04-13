using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace VoteSystem.Models
{
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
}