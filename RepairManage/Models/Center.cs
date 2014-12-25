using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RepairManage.Models
{
    public class Center
    {
        [Key]
        public int centerId { get; set; }
        [Display(Name = "维修中心名称")]
        public string name { get; set; }
        [Display(Name = "地址")]
        public string address { get; set; }
        [Display(Name = "电话")]
        public string phone { get; set; }
        [Display(Name = "邮箱")]
        public string email { get; set; }
    }
}