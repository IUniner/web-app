using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class EmployeeProfile
    {
        public int Id {get; set;}
        public Employee employee { get; set; }
    }
}