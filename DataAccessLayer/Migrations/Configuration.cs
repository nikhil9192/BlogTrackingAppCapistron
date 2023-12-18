namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BlogApp;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogApp.Context.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "BlogDAL.BlogDbContext";
        }

        protected override void Seed(BlogApp.Context.BlogContext context)
        {
            var admin = new AdminInfo
            {
                EmailId = "Nikhil@admin.com",
                Password = "Nik@1234"
            };
            context.AdminInfos.Add(admin);

            var employee = new EmpInfo
            {
                EmailId = "Nikhil@emp.com",
                PassCode = "Nik@1234"
            };
          //  context.AdminInfos.Add();

            // Add additional seeding for other tables if needed

            base.Seed(context);
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
