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
            //
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