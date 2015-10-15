using ElandBJ.ScheduledJob.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTestRemote.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        IEmailManager em = Spring.Context.Support.ContextRegistry.GetContext().GetObject("RemoteEmailManager") as IEmailManager;

        public ActionResult Index()
        {
            return View();
        }

        public void AddJob()
        {
            em.AddTrigger("0/2 * * * * ?", "test");
        }

        public void RemoveJob()
        {
            em.RemoveTrigger("test");
        }

        public void ModifyJob()
        {
            em.ModifyTrigger("0/6 * * * * ?", "test");
        }

        public void CommonAPI()
        {
            em.TriggerScheduled();
        }

    }
}
