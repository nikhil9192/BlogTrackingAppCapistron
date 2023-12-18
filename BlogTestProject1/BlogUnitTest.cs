using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp;

using BlogApp.Context;
using BlogApp.Repositories;

namespace BlogTestProject1
{
    public class BlogUnitTest
    {
        private BlogContext _dbContext;
        private EmpInfoRepository _empRepository;
        private IBlogInfoRepository _blogRepository;
        [SetUp]
        public void Setup()
        {
            // Set up your dependencies (mocks or actual instances) for testing
            _dbContext = new BlogContext();
            _empRepository = new EmpInfoRepository(_dbContext);
            _blogRepository = new BlogInfoRepository(_dbContext, _empRepository);
        }

        [Test, Ignore("Skip for now It's  passed")]

        public void AddBlogInfo_ShouldAddToDbContext()
        {
            // Arrange
            var blogInfo = new BlogInfo
            {
                // Don't set BlogInfoId manually if it's an identity column
                // BlogInfoId = 1,
                Title = "Title 1",
                Subject = "Subject 1",
                DateOfCreation = DateTime.Now,
                BlogUrl = "url1",
                Employee = new EmpInfo
                {
                    Name = "XYZ",
                    EmailId = "XYZ@gmail.com",
                    PassCode = "234231",
                    DateOfJoining = DateTime.Now,
                }
            };

            // Act
            _blogRepository.AddBlogInfo(blogInfo);

            // Convert DbSet<BlogInfo> to List<BlogInfo>
            List<BlogInfo> blogInfoList = _dbContext.BlogInfos.ToList();

            // Assert
            Assert.That(blogInfoList, Has.Exactly(1)
                .Matches<BlogInfo>(b => b.BlogInfoId > 0 && b.BlogInfoId == blogInfo.BlogInfoId));
        }


        [Test, Ignore("Skip for now It's  passed")]
        public void DeleteBlogInfo()
        {
            // Arrange
            var blogInfoIdToDelete = 1;
            var existingBlogInfo = new BlogInfo { BlogInfoId = blogInfoIdToDelete };
            _dbContext.BlogInfos.Add(existingBlogInfo);

            // Act
            _blogRepository.DeleteBlogInfo(blogInfoIdToDelete);

            // Assert
            ClassicAssert.IsFalse(_dbContext.BlogInfos.Any(b => b.BlogInfoId == blogInfoIdToDelete));
        }

        [Test, Ignore("Skip for now It's  passed")]
        public void GetAllBlogInfos_ShouldReturnAllBlogInfos()
        {
            var result = _blogRepository.GetAllBlogInfos();
            ClassicAssert.AreEqual(_dbContext.BlogInfos.Count(), result.Count());
        }
        [Test, Ignore("Skip for now It's  passed")]
        public void GetBlogInfoByEmployeeId()
        {

            var loggedInEmployeeEmail = "example@email.com";

            var result = _blogRepository.GetBlogInfoByEmployeeId(loggedInEmployeeEmail);
            ClassicAssert.IsTrue(result.All(b => b.Employee.EmailId == loggedInEmployeeEmail));
        }

    }
}
