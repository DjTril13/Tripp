using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planner.Models;
using System.Data.Entity;
using Planner.Models.ViewModels;

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
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Create(string Title)
        {
             Activities Activity = new Activities();
            Activity.Title = Title;
            _context.Activities.Add(Activity);
            _context.SaveChanges();
            return View("Details", "Docket");    // pass thru the ID?
        }
    }
}