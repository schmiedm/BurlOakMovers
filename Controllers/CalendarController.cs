using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurlOakMovers.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (Entities2 dc = new Entities2())
            {
                var events = dc.TestEvents.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(TestEvent e)
        {
            var status = false;
            using (Entities2 dc = new Entities2())
            {
                if (e.id > 0)
                {
                    var v = dc.TestEvents.Where(a => a.id == e.id).FirstOrDefault();
                    if (v != null)
                    {
                        v.IsFullDay = e.IsFullDay;
                        v.Start = e.Start;
                        v.Subject = e.Subject;
                        v.Description = e.Description;
                        v.ThemeColor = e.ThemeColor;
                        v.End = e.End;
                    }
                }
                else
                {
                    dc.TestEvents.Add(e);
                }
                dc.SaveChanges();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;

            using (Entities2 dc = new Entities2())
            {
                var v = dc.TestEvents.Where(a => a.id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.TestEvents.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }

                return new JsonResult { Data = new { status = status } };
        }
    }
}