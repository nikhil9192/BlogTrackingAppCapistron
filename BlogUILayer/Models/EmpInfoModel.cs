using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogUILayer.Models
{
    public class EmpInfoModel
    {
        [Key]
        public int EmpInfoId { get; set; }
        [Index("UQ_EmailId", IsUnique = true)]
        [MaxLength(255)]
        public string EmailId { get; set; }
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }
        public string PassCode { get; set; }
        public string cnfrmPassword { get; set; }
    }
}