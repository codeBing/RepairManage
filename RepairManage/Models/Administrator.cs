using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RepairManage.Models
{
    public class Administrator
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="用户名不能为空")]
        [Display(Name="用户名")]
        public string adminName { get; set; }
        [Required(ErrorMessage="密码不能为空")]
        [DataType(DataType.Password)]
        [Display(Name = "密码")]
        public string adminPwd { get; set; }
    }
}