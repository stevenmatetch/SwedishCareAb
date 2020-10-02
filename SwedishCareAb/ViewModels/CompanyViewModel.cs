using SwedishCareAb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.ViewModels
{
 public   class CompanyViewModel
    {
        public List<Company> companies { get; set; } 
        public CompanyViewModel()
        {
            companies = new List<Company>();
            companies.Add(new Company( "Fålktandvården Skåne", "Östra Vallgatan 35 C 223 61 Lund", "046-211 80 92", "klinik@kantand.se" , "Mån-Tors 7.30-17.00\nFre 7.30 - 13.00 \nAndra tider enligt överenskommelse", "Assets/folktandVården.gif"));
        }
    }
    
}
