using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Context;

namespace BlogApp.DatabaseInitializer
{
    // BlogInitializer.cs
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            // Add default data to AdminInfo table
            context.AdminInfos.Add(new AdminInfo { EmailId = "nikhil@example.com", Password = "nikhil" });
            context.SaveChanges();

            base.Seed(context);
        }
    }

}
