﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planner.Models
{
    public class Docket             
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Activites> Activities { get; set; }

    }
}