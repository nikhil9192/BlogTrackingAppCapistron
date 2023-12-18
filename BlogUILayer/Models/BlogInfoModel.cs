using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BlogApp;

namespace BlogUILayer.Models
{
    public class BlogInfoModel
    {
        [Key]
        public int BlogInfoId { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string BlogUrl { get; set; }
        public string Name  { get; set; }

    }
}