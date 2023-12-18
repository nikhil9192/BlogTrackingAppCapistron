using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataServiceLayer.Models
{
    public class BlogInfo
    {
      
        public int BlogInfoId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string BlogUrl { get; set; }
        public virtual EmpInfo Employee { get; set; }
    }
}