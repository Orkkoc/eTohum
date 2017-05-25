using System;
using eTohumApplication.Models.Base;
using eTohumApplication.Controllers.Services;
using System.Web.Mvc;

namespace eTohumApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Ana Sayfa";

            return View();
        }
        /* <return> SetBsUser Service result as Json */
        public JsonResult SetBsUser(BsUser bsUser)
        {
            OperationResult result = new OperationResult();

            try
            {
                OperationResult operationResult = DbServices.SetBsUser(bsUser);

            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
            }

            return Json(new
            {
                Message = result.Message,
                ErrorMessage = result.ErrorMessage,
                Result = result.Result,
                ErrorType = result.ErrorType,
                Results = result.Response
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
