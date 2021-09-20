using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Subs.WebApi.Models
{
    public class UserTemplate
    {
        public int CustomerId { get; set; }
        public int TitleId { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string LoginEmail { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        //public int CountryId { get; set; }
        //public string Province { get; set; }
        //public string City { get; set; }
        //public string Street { get; set; }
        //public string StreetExtension { get; set; }
        //public string StreetSuffix { get; set; }
        //public string StreetNo { get; set; }
        //public string Building { get; set; }
        //public string Floor { get; set; }
        //public string Room { get; set; }
    }
}