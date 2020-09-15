﻿using BurlOakMovers.Models;
using BurlOakMovers.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
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
            using (Entities3 dc = new Entities3())
            {
                var events = dc.TestEvents.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
        [HttpPost]
        public JsonResult SaveEvent(AddEventModel e)
        {
            Debug.Print("PLESE DONT BE 000000000                 " + e.StartDate.ToString());
            Debug.Print("Save Event ");
            var status = false;
            using (Entities3 dc = new Entities3())
            {
                if (e.EventId > 0)
                {
                    TestEvent v = dc.TestEvents.Where(a => a.id == e.EventId).FirstOrDefault();
                    if (v != null)
                    {
                        v.IsFullDay = e.FullDay;
                        v.Start = e.StartDate;
                        v.Subject = e.Subject;
                        v.Description = e.Description;
                        v.ThemeColor = e.ThemeColor;
                        v.End = e.EndDate;
                        Debug.Print("Update Event");
                    }
                }
                else
                {
                    TestEvent objEvent = new TestEvent()
                    {
                        Subject = e.Subject,
                        Description = e.Description,
                        Start = e.StartDate,
                        End = e.EndDate,
                        ThemeColor = e.ThemeColor
                    };
                    Debug.Print(e.StartDate.ToString());
                    Debug.Print(objEvent.Start.ToString());
                    dc.TestEvents.Add(objEvent);
                    Debug.Print("New Event");

                }





                    


                try
                {
                    dc.SaveChanges();
                    status = true;
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }




            }
            return new JsonResult { Data = new { status = true }};
        }

        [HttpPost]
        public JsonResult DeleteEvent(int id)
        {
            var status = false;

            using (Entities3 dc = new Entities3())
            {
                var v = dc.TestEvents.Where(a => a.id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.TestEvents.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }

                return new JsonResult { Data = new { status = true } };
        }

    }
}