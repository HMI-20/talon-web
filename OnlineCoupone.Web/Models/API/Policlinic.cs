using System.Collections.Generic;

namespace OnlineCoupone.Web.Models.API
{
    public class Policlinic
    {
        public int PoliclinicId { get; set; }
        public string Title { get; set; }
        public List<Doctor> Staff { get; set; }
    }
}