using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Planner.Models.ViewModels
{
    public class ActivityDocketViewModel
    {
        public Docket Docket { get; set; }
        public Activites Activities { get; set; }
        public List<Activites> ActivitiesList { get; set; }

        [Required]
        [Display(Name = "New Activity")]
        public Activites NewActivity = new Activites();
}
}