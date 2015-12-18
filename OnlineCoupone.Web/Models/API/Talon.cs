using System;

namespace OnlineCoupone.Web.Models.API
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