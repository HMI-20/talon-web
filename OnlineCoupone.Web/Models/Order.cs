using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineCoupone.Web.Models
{
    public class Order
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public string Address { get; set; }
    }
}