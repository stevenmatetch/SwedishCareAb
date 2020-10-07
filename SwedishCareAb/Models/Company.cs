using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.Models
{
  public   class Company 
    {
        public int ID { get; set; }
        public string Name { get; set; }
       
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
      
        public string OpeningHours { get; set; }
        public string Picture { get; set; }

   
        public Company(string name, string address, string phoneNumber, string mail, string openingHours, string picture)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Address = address;
            Mail = mail;
            OpeningHours = openingHours;
            Picture = picture;

        }

        public Company() { }
      
    }
}
