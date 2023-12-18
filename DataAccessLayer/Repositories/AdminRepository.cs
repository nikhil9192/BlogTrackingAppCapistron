using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Context;

namespace BlogApp.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly BlogContext _dbContext;

        public AdminRepository(BlogContext blogDbContext)
        {
            _dbContext = new BlogContext();
        }

        public AdminInfo GetAdminInfoByEmailId(string EmailId)
        {
            return _dbContext.AdminInfos.FirstOrDefault(admin => admin.EmailId == EmailId);
        }

        public IEnumerable<AdminInfo> GetAllAdminInfos()
        {
            return _dbContext.AdminInfos.ToList();
        }

        public void AddAdminInfo(AdminInfo adminInfo)
        {
            _dbContext.AdminInfos.Add(adminInfo);
        }

        public void UpdateAdminInfo(AdminInfo adminInfo)
        {
            _dbContext.Entry(adminInfo).State = EntityState.Modified;
        }

        public void DeleteAdminInfo(int adminInfoId)
        {
            var adminInfo = _dbContext.AdminInfos.Find(adminInfoId);
            if (adminInfo != null)
                _dbContext.AdminInfos.Remove(adminInfo);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
