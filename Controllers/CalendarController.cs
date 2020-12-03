
using BurlOakMovers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurlOakMovers.Controllers
{
    [Authorize]
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            using (BurlOakMovers20200923103337_dbEntities1 dc = new BurlOakMovers20200923103337_dbEntities1())
            {
                var events = dc.Events.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }

        [HttpPost]
        public JsonResult SaveEvent(Event events)
        {
            var status = false;
            using (BurlOakMovers20200923103337_dbEntities1 dc = new BurlOakMovers20200923103337_dbEntities1())
            {
                if (events.EventID > 0)
                {
                    var valid = dc.Events.Where(a => a.EventID == events.EventID).FirstOrDefault();
                    

                    if (valid != null)
                    {
                        valid.Subject = events.Subject;
                        valid.Start = events.Start;
                        valid.End = events.End;
                        valid.Description = events.Description;
                        valid.IsFullDay = events.IsFullDay;
                        valid.ThemeColor = events.ThemeColor;
                    }
                }
                else
                {
                    dc.Events.Add(events);
                }

                dc.SaveChanges();
                status = true;
            }

            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            using (BurlOakMovers20200923103337_dbEntities1 dc = new BurlOakMovers20200923103337_dbEntities1())
            {
                var valid = dc.Events.Where(a => a.EventID == eventID).FirstOrDefault();
                if (valid !=null)
                {
                    dc.Events.Remove(valid);
                    dc.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };
        }
    }
}