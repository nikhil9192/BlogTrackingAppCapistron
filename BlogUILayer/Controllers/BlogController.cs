using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogApp;
using BlogApp.Repositories;
using BlogUILayer.Models;

namespace BlogUILayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogInfoRepository _blogRepository;
        private readonly IEmpInfoRepository empRepository;

        public BlogController(IBlogInfoRepository blogReposotiry, IEmpInfoRepository empRepository)
        {
            this._blogRepository = blogReposotiry;
            this.empRepository = empRepository;
        }
        // GET: log
        public ActionResult Index()
        {

            var blogs = _blogRepository.GetAllBlogInfos();
            var blogViewModels = blogs.Select(blog => new BlogViewModel
            {

                Title = blog.Title,
                Subject = blog.Subject,
                DateOfCreation = blog.DateOfCreation,
                BlogUrl = blog.BlogUrl,
                EmployeeName = blog.Employee.Name
            }).ToList();
            return View(blogViewModels);
        }

        // GET: log/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: log/Create
        [HttpPost]
        public ActionResult Create(AddBlogModel blogInfo)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid)
                {
                    string loggedInEmployee = (string)Session["EmailId"];

                    BlogInfo blog = new BlogInfo
                    {
                        Title = blogInfo.Title,
                        Subject = blogInfo.Subject,
                        DateOfCreation = DateTime.Now,
                        BlogUrl = "https://designyourownblog.com/blog/",
                    };

                    _blogRepository.AddBlogWithForeignKey(loggedInEmployee, blog);

                    return RedirectToAction("Home", "Employee"); // Redirect to the blog list or another action
                }

                return View(blogInfo);

               
            }
            catch
            {
                return View();
            }
        }

        // GET: log/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: log/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: log/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: log/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
