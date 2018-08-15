using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Activities
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int DocketId { get; set; }
        public Docket Docket { get; set; }

    }
}