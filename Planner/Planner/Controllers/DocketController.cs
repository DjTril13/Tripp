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
    public class DocketController : Controller
    {

        private ApplicationDbContext _context;

        public DocketController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Docket
        public ActionResult Details(int Id)
        {
            Docket Docket = _context.Docket
             .Include(d => d.Activities)
             .Where(d => d.Id == Id)
             .SingleOrDefault();


            ViewBag.Title = "Activities List";
            return View(Docket);
        }
    }
        //public ActionResult Details() { }// single docket when you click it from home page
    }


