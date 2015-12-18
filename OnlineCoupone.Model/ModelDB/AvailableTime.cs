using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoupone.Model.ModelDB
{
    public class AvailableTime
    {
        public int AvailableTimeId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public DateTime Time { get; set; }
    }
}
