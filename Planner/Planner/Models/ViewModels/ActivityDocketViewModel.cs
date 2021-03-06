﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models.ViewModels
{
    public class ActivityDocketViewModel
    {
        public Docket Docket { get; set; }
        [Required]
        public string Title { get; set; }
        [Display(Name = "New Activity")]
        public Activities Activities { get; set; }
       
        public List<Activities> ActivitiesList { get; set; }

    }
  
}