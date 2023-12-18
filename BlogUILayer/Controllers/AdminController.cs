using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BlogApp;
using BlogApp.Repositories;
using BlogUILayer.Models;
using DataAccessLayer.Authentication;

namespace BlogUILayer.Controllers
{
    public class AdminController : Controller
    {



        private readonly IAuthService authService;
        private readonly IAdminRepository adminRepository;
        private readonly IEmpInfoRepository empRepository;

        public AdminController(IAuthService authService, IAdminRepository adminRepository
            , IEmpInfoRepository empRepository)
        {
            this.authService = authService;
            this.adminRepository = adminRepository;
            this.empRepository = empRepository;
        }


        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        //public ActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]


        public ActionResult Login(LoginViewModel model)
        {
            // Add authentication logic for Employee login
            if (ModelState.IsValid)
            {
                bool Authres = authService.Authenticate(model.EmailId, model.Password, UserRole.Admin);
                if (Authres)
                {
                    var employee = adminRepository.GetAdminInfoByEmailId(model.EmailId);
                    Session["EmailId"] = model.EmailId;
                    return RedirectToAction("Home", "Admin");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    // Add a flag to indicate unsuccessful login attempt
                    ModelState.AddModelError("LoginFailed", "true");
                }
            }
            return View(model);
        }



        //public ActionResult Login(string email, string password)
        //{
        //    // Validate admin credentials
        //    if (email == "admin@example.com" && password == "adminpassword")
        //    {
        //        // Admin authentication successful
        //        // Redirect to admin dashboard or perform other actions
        //        return RedirectToAction("AdminDashboard");
        //    }

        //    // Admin authentication failed
        //    ViewBag.ErrorMessage = "Invalid credentials";
        //    return View();
        //}

        //public ActionResult AdminDashboard()
        //{
        //    return View();
        //}


        // GET: Admin/Create
        public ActionResult Home()
        {
            var employeeList = empRepository.GetAllEmpInfos();
            var employeeViewModelList = employeeList.Select(admin => new EmpInfoModel
            {
                EmailId = admin.EmailId,
                Name = admin.Name,
                DateOfJoining = admin.DateOfJoining
            });
            // Map ot
            return View(employeeViewModelList);
        }


        [HttpGet, ActionName("Create")]
        public ActionResult Create()
        {
            EmpInfoModel model = new EmpInfoModel
            {

                DateOfJoining = DateTime.Now,
            };
            return View(model);
        }

        [HttpPost, ActionName("Create")]
        public ActionResult CreateEmployee(EmpInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var NewEmploye = new EmpInfo
                {
                    Name = model.Name,
                    DateOfJoining = model.DateOfJoining,
                    EmailId = model.EmailId,
                    PassCode = model.PassCode
                };
                empRepository.AddEmpInfo(NewEmploye);
                return RedirectToAction("Home", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Something went wrong ";
                return View("Create", "Admin");
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {

            var employee = empRepository.GetEmpInfoById(id);

            if (employee != null)
            {

                var employeeViewModel = new EmpInfoModel
                {
                    EmpInfoId = employee.EmpInfoId,
                    Name = employee.Name,
                    EmailId = employee.EmailId,
                    DateOfJoining = employee.DateOfJoining,
                    PassCode = employee.PassCode
                };
                return View(employeeViewModel);
            }

            // Map the employee data to your view model


            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(EmpInfoModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                // Map the view model data back to your data model
                var employee = new EmpInfo
                {
                    DateOfJoining = employeeViewModel.DateOfJoining,
                    EmpInfoId = employeeViewModel.EmpInfoId,
                    Name = employeeViewModel.Name,
                    EmailId = employeeViewModel.EmailId,
                    PassCode = employeeViewModel.PassCode
                };

                empRepository.UpdateEmpInfo(employee);
                return RedirectToAction("Home", "Admin"); // Redirect to the index action or another appropriate action
            }
            else
            {
                TempData["ErrorMessage"] = "Something went wrong ";
                return View("Edit", "Admin");
            }
        }


        [HttpPost]
        public ActionResult Delete(int Id)
        {

            var temp = empRepository.GetEmpInfoById(Id);
            if (temp != null)
            {
                empRepository.DeleteEmpInfo(temp.EmpInfoId);
                return RedirectToAction("Home", "Admin");
            }
            else
            {
                TempData["ErrorMessage"] = "Something went wrong ";
                return RedirectToAction("Home", "Admin");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Blog");
        }
    }

    

}