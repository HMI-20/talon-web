using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCoupone.Web.Models
{
    public class Talon
    {
        public int TalonId { get; set; }
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public string DateToShow { get; set; }
        public string TimeToShow { get; set; }
    }
}