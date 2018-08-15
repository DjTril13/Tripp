using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Docket
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public List<Activities> Activities { get; set; }
        public string UserId {get; set;}
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}