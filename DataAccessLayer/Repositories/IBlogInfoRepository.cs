using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public interface IBlogInfoRepository
    {
        BlogInfo GetBlogInfoById(int blogInfoId);
        IEnumerable<BlogInfo> GetAllBlogInfos();
        void AddBlogInfo(BlogInfo blogInfo);
        IEnumerable<BlogInfo> GetBlogInfoByEmployeeId(string EmailId);
        void UpdateBlogInfo(BlogInfo blogInfo);
        void DeleteBlogInfo(int blogInfoId);
        void AddBlogWithForeignKey(string loggedInEmployeeEmail, BlogInfo blogInfo);
        void SaveChanges();
    }
}
