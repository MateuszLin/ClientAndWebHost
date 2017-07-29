using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebHostB.Models;

namespace WebHostB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            startServer();
            return View();
        }

        /// <summary>
        /// Start server host
        /// </summary>
        private void startServer()
        {
            ServerHost host = new ServerHost();
            host.startServer();
        }

        [HttpPost]
        public ActionResult GetMessage()
        {
            if (MessageModel.message == null)
                return Content("");
            return Content(MessageModel.message);
        }
    }
}