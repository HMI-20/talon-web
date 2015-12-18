using System;
using System.Collections.Generic;

namespace OnlineCoupone.Web.Models.API
{
    public class Doctor
    {
        public int DoctorId { get; set; }
        public string Fio { get; set; }
        public Speciality Speciality { get; set;}
        public List<List<DateTime>> FreeSession { get; set; }
    }
}