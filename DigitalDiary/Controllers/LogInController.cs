using DigitalDiary.Interfaces;
using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class LogInController : Controller
    {
        IUserRepository URepo = new UserRepository();
      
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            var LogInDetails = URepo.GetLogInInfo(u.Username, u.Password);
            if (LogInDetails == null)
            {
                return View("Index");
            }
            else
            {
                Session["UserId"] = LogInDetails.UserId;
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LogIn");
        }
    }
}