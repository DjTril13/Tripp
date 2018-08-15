using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planner.Models;
using System.Data.Entity;
using Planner.Models.ViewModels;
using System.Configuration;
using System.IO;

namespace Planner.Controllers
{
    public class ActivityController : Controller
    {
        private ApplicationDbContext _context;

        public ActivityController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(int ModelId)
        {
           
            ActivityDocketViewModel NewActivities = new ActivityDocketViewModel();
            NewActivities.Activities = new Activities();
            NewActivities.Activities.DocketId = ModelId;
            NewActivities.ActivitiesList = _context.Activities
                .Include(a => a.Docket)
                .Where(a => a.DocketId == ModelId)
                .ToList();

            return View(NewActivities);
        }
        [HttpPost]
        public ActionResult Add(ActivityDocketViewModel Advm )  //this will have to change to the view model im using above?
        {
            Activities NewActivity = new Activities();
            NewActivity.DocketId = Advm.Activities.DocketId;
            NewActivity.Title = Advm.Title;
            NewActivity.Lat = Advm.Activities.Lat;
            NewActivity.Lng = Advm.Activities.Lng;
            _context.Activities.Add(NewActivity);
            _context.SaveChanges();

            Docket Docket = _context.Docket
          .Include(d => d.Activities)
          .Where(d => d.Id == NewActivity.DocketId)
          .SingleOrDefault();
            ViewBag.Title = "Activities List";
            return RedirectToAction("Details", "Docket", Docket);    // pass thru the ID?
        }

    }
}