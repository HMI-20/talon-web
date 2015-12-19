using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoupone.Model.ModelDB
{
    public class VisitHistory
    {
        public int VisitHistoryId { get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public AvailableTime AvailableTime { get; set; }
    }
}
