using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MFlorist.DataAccessLayer;
using System.Web.Security;

namespace MaynoothFloristSite.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
         
        public ActionResult Login(User user, string returnUrl)
        {

            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                using (UserEntity db = new UserEntity())
                {
                    var v = db.Users.Where(a => a.Username.Equals(user.Username) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (v != null)
                    { 

                        //Session["LogedUserID"] = v.UserID.ToString();
                        //Session["LogedUserFullname"] = v.FullName.ToString();
                        FormsAuthentication.SetAuthCookie(user.Username, false);
                        return RedirectToLocal(returnUrl);
                    }
                }
               
            }
            return View(user);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}