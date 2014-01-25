using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Lawyer.ViewModel;
using Lawyer.Data;
using Lawyer.Helper;

namespace Lawyer.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserHelper _UserHelper = new UserHelper();
        public AccountController()
        {
            _UserHelper =  new UserHelper();
        }

        public ActionResult Login()
        {
            ViewBag.ReturnUrl = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            return View();
        }
    }
}