﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Subs.MimsWeb.Models
{
    public class ListItem
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class UserTemplate
    {
        public int CustomerId { get; set; }

        [Display(Name = "Title")]
        [Required]
        public int TitleId { get; set; }
        public SelectList TitleSelectList { get; set; }

        [Required]
        public string Initials { get; set; }

        [Display(Name ="First name")]
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [UIHint("EmailAddress")]
        [Required]
        public string EmailAddress { get; set; }

        [UIHint("Password")]
        [Required]
        public string Password { get; set; }

        [Required]
        [UIHint("Password")]
        public string ConfirmedPassword { get; set; }


        [UIHint("Tel")]
        [Required]
        public string PhoneNumber { get; set; }

        [UIHint("Tel")]
        [Required]
        public string CellPhoneNumber { get; set; }
        public string NationalId1 { get; set; }
        public string NationalId2 { get; set; }
        public string NationalId3 { get; set; }
        public string VatRegistration { get; set; }
        public string GovernmentSupplierNumber { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CouncilNumber { get; set;}
        [Required]
        public string CompanyNaam { get; set; }
        public string Department { get; set; }

        [Display(Name= "Postal address line 1")]
        [Required]
        public string Address1 { get; set; }

        [Display(Name = "Postal address line 2")]
        [Required]
        public string Address2 { get; set; }

        [Display(Name = "Postal address line 3")]
        [Required]
        public string Address3 { get; set; }
        [Display(Name = "Postal address line 4")]
        public string Address4 { get; set; }

        [Display(Name = "Country")]
        [Required]
        public int CountryId { get; set; }
        public SelectList CountrySelectList { get; set; }

        [Required]
        [Display(Name = "Postal code")]
        public string Address5 { get; set; }

        [Display(Name = "Account email")]
        public string AccountsEMail { get; set; }

        public string WebURL { get; set; }

        [Display(Name = "Correspondence")]
        public int Correspondence2 { get; set; }

        public bool Proforma { get; set; }
        public decimal Deliverable { get; set; }
        [Required]
        public int PhysicalAddressId { get; set; }
        [Required]
        public int DeliveryAddressId { get; set; }
        [Required]
        public string Province { get; set; }

        public int Classification1Id { get; set;}
       
        public SelectList Classification1SelectList { get; set; }

        public int? Classification2Id { get; set; }
        public SelectList Classification2SelectList { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public string Street { get; set; }
        public string StreetExtension { get; set; }
        public string StreetSuffix { get; set; }
        [Required]
        public string StreetNo { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Room { get; set; }
        [Required]
        public string PostCode { get; set; }

    }
}