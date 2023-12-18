using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataServiceLayer.Models
{
    public class AdminInfo
    {
        public int AdminInfoId { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}