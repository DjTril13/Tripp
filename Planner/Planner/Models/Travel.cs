using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public DateTime Depature { get; set; }
        public DateTime Arrival { get; set; }
        public string Comments { get; set; }
        public string TicketLink { get; set; }
    }
}