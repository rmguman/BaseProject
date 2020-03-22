using Project.DataTier.Model.ORM.Context;
using Project.DataTier.Model.ORM.Entity;
using Project.Web.Model.Types;
using Project.Web.Model.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Web.Controllers
{
    
    public class AccountController : BaseController
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                bool webusercontrol = unit.WebUserRepo.Any(x => x.EMail.ToLower() == model.Email || x.Nickname.ToLower() == model.NickName.ToLower());
                if (!webusercontrol)
                {
                    WebUser webuser = new WebUser();
                    webuser.Name = model.FirstName;
                    webuser.Surname = model.LastName;
                    webuser.EMail = model.Email;
                    webuser.Nickname = model.NickName;
                    unit.WebUserRepo.Add(webuser);
                    ViewBag.IslemDurum = EnumIslemDurum.IslemBasarili;

                    FormsAuthentication.SetAuthCookie(webuser.EMail, true);

                }
                else
                {
                    ShowMessage(new List<string>() { "Email address or password is incorrect." }, "register");
                    ViewBag.IslemDurum = EnumIslemDurum.EmailHata;
                }
                
            }
            else
            {
                ShowMessage(new List<string>() { "Email address or password is incorrect." }, "register");
                ViewBag.IslemDurum = EnumIslemDurum.ValidationHata;
                
            }
            return RedirectToAction("Index", "Home");
           
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}