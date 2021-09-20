using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subs.MimsWeb.Models
{
    public class LoginRequest
    {
        public string Email {get ; set;}
        public string Password { get; set; }
        public int? CustomerId { get; set; }
        public int CountryId { get; set; }
        public int PhysicalAddressId { get; set; }
        public bool ResetPassword { get; set;}
    }
}