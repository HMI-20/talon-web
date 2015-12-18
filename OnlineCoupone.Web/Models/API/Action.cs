using System;

namespace OnlineCoupone.Web.Models.API
{
    public class Action
    {
        public int ActionId { get; set; }
        public ActionType ActionType { get; set; }
        public DateTime Date { get; set; }
        public Doctor Doctor { get; set; }
        public string DateToShow { get; set; }
        public string TimeToShow { get; set; }
    }
}