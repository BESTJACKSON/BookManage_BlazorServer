using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookManage.Models;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace BookManage.Controllers
{
    public class AccountsController : Controller
    {
        private BookContext db = new BookContext();
        public ClaimsIdentity CreateIdentity(Account user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.id.ToString()));
          _identity.AddClaim(new Claim(ClaimTypes.Name, user.user));
            return _identity;
        }
        private IAuthenticationManager AuthenticationManager
        {
            get { return HttpContext.GetOwinContext().Authentication; }
        }
        [HttpGet]
        public ActionResult Login()
        {
            try
            {
                return View("Login");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (ModelState.IsValid)
            {
                var _user = db.Accounts.SingleOrDefault(t => t.user == model.user);
                if (_user == null) ModelState.AddModelError("user", "Username does not exist!");
                else if (_user.Password == model.Password)
                {
                    var _identity = CreateIdentity(_user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, _identity);
                    return RedirectToAction("Index", "Book");
                }
                else ModelState.AddModelError("Password", "Wrong password!");
            }
            return View();
        }
    }
}
