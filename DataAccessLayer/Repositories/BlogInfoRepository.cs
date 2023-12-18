using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Context;

namespace BlogApp.Repositories
{
    public class BlogInfoRepository : IBlogInfoRepository
     {
        private readonly BlogContext _dbContext;
        private readonly EmpInfoRepository empRepository;

        public BlogInfoRepository(BlogContext blogDbContext, EmpInfoRepository empRepository)
        {
            this._dbContext = blogDbContext;
            this.empRepository = empRepository;
        }

        public BlogInfoRepository()
        {
        }

        public void AddBlogInfo(BlogInfo blogInfo)
        {
            _dbContext.BlogInfos.Add(blogInfo);
        }

        public void DeleteBlogInfo(int blogInfoId)
        {
            var blogInfo = _dbContext.BlogInfos.Find(blogInfoId);
            if (blogInfo != null)
                _dbContext.BlogInfos.Remove(blogInfo);
        }

        public IEnumerable<BlogInfo> GetAllBlogInfos()
        {
            return _dbContext.BlogInfos.Include(blog => blog.Employee).ToList();
        }
        public IEnumerable<BlogInfo> GetBlogInfoByEmployeeId(string EmailId)
        {
            return _dbContext.BlogInfos
        .Include(b => b.Employee)  // Include the Employee navigation property
        .Where(b => b.Employee.EmailId == EmailId)  // Filter based on the Employee's EmailId
        .ToList();
        }
        public BlogInfo GetBlogInfoById(int blogInfoId)
        {
            return _dbContext.BlogInfos.Find(blogInfoId);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void AddBlogWithForeignKey(string loggedInEmployeeEmail, BlogInfo blogInfo)
        {
            EmpInfo loggedInEmployeeEntity = empRepository.GetEmpInfoByEmialId(loggedInEmployeeEmail);

            if (_dbContext.Entry(loggedInEmployeeEntity).State == EntityState.Detached)
            {
                _dbContext.EmpInfos.Attach(loggedInEmployeeEntity);
            }

            blogInfo.Employee = loggedInEmployeeEntity;
            _dbContext.BlogInfos.Add(blogInfo);
            _dbContext.SaveChanges();
        }
        public void UpdateBlogInfo(BlogInfo blogInfo)
        {
            _dbContext.Entry(blogInfo).State = EntityState.Modified;
        }
    }
}
