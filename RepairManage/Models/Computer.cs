using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RepairManage.Models
{
    public class Computer
    {
        
        //public int ID { get; set; }
        [Key]
        [Display(Name = "序列号")]
        public int computerId { get; set; }
        [ScaffoldColumn(false)]
        public int centerId { get; set; }
        [Display(Name = "过保日期")]
        [DataType(DataType.Date)]
        public DateTime deadTime { get; set; }

        public virtual Center center { get; set; }
    }
}