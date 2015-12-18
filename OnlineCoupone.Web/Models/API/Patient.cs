using System;
using System.Collections.Generic;

namespace OnlineCoupone.Web.Models.API
{
    public class Patient
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime DateOfBirthday;
        public string Town { get; set; }
        public string Address { get; set; }
        public List<Action> History { get; set; }
    }
}