using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSessCookie.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //we need post to reflect the view
        [HttpPost]
        public ActionResult Index(string name)
        {
            //we do not create any thing inside session
            if (Session["Names"]==null)
            {
                List<string> names = new List<string>();
                names.Add(name);
                //here session has first name from list time, it will save first value
                Session["Names"] = names;
            }
            // for next time the session will come here 
            else
            {
                //We cast the session because session dos not remmber what type it is
                List<string> names = (List<string>)Session["Names"];//must type cast session
                names.Add(name);//second time add to list
                Session["Names"] = names;// assign to session
            }
            return View();
        }
    }
}