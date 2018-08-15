using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageFilePath { get; set; }
        public int ActivitiesId { get; set; }
        public string Caption { get; set; }
    }
}