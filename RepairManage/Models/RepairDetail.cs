using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RepairManage.Models
{
    public class RepairDetail
    {
        [Key]
        public int repairId { get; set; }
        [Required(ErrorMessage="请输入序列号")]
        [Display(Name = "电脑序列号")]
        public int computerId { get; set; }

        [Required(ErrorMessage = "请输入故障信息")]
        [Display(Name = "故障信息")]
        [DataType(DataType.MultilineText)]
        public string faultMsg { get; set; }

        [Required(ErrorMessage = "请输入维修方式")]
        [Display(Name = "维修方式")]
        [DataType(DataType.MultilineText)]
        public string repairMethod { get; set; }

        [Required(ErrorMessage = "请输入维修费用（如在保修期内请填0）")]
        [Display(Name = "维修费用")]
        public Double repairCost { get; set; }

        [Required(ErrorMessage = "请输入维修日期")]
        [Display(Name = "维修日期")]
        [DataType(DataType.Date)]
        public DateTime repairTime { get; set; }

        [Display(Name = "维修状态")]
        public bool isFixed { get; set; }

        [Required(ErrorMessage = "请输入客户名称")]
        [Display(Name = "客户名称")]
        public string customerName { get; set; }

        [Required(ErrorMessage = "请输入客户电话号码")]
        [Display(Name = "客户电话")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "请输入客户邮箱")]
        [Display(Name = "客户邮箱")]
        public string email { get; set; }


    }
}