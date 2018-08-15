using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class MyExperiences
    {
        public int Id { get; set; }
        public int ActivitiesId { get; set; }
        public List<Image> MyImages { get; set; }
        
        public string Comments { get; set; }
    }
}