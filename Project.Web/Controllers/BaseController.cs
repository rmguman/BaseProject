using Project.Business.Manager.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Web.Controllers
{
    public class BaseController : Controller
    {
        public UnitOfWork unit;
        public BaseController()
        {
            unit = new UnitOfWork();
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            ViewBag.NickName = GetNickName();
        }


        public string GetNickName()
        {
            string email = HttpContext.User.Identity.Name;
            var user = unit.WebUserRepo.FirstOrDefault(x => x.EMail == email);
            if (user!=null)
            {
                return user.Nickname;
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg">Modal Messages</param>
        /// <param name="modalName">Modal Name</param>
        public void ShowMessage(List<string> msg, string modalName)
        {
            msg.Add(modalName);
            TempData["ModalMessages"] = msg;
        }
    }
}