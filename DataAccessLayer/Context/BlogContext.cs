using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Context
{
    // BlogContext.cs
    public class BlogContext : DbContext
    {

        public BlogContext() : base("name=BlogContext")
        {
             Database.SetInitializer < BlogContext > (null);

        }
        public DbSet<AdminInfo> AdminInfos { get; set; }
        public DbSet<EmpInfo> EmpInfos { get; set; }
        public DbSet<BlogInfo> BlogInfos { get; set; }

       // public System.Data.Entity.DbSet<BlogUILayer.Models.BlogInfoModel> BlogInfoModels { get; set; }

        // public System.Data.Entity.DbSet<BlogUILayer.Models.BlogInfoModel> BlogInfoModels { get; set; }
    }

}
