using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCoupone.Model.ModelDB
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Fio { get; set; }
        public Specialization Specialization { get; set; }
        public Policlinic Policlinic { get; set; }
    }
}
