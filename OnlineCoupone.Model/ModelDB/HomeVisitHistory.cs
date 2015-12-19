using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoupone.Model.ModelDB
{
    public class HomeVisitHistory
    {
        public int HomeVisitHistoryId { get; set; }
        public Patient Patient { get; set; }
        public DateTime Date { get; set; }
        public Policlinic Policlinic { get; set; }
    }
}
