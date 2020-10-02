using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.Models
{
   public class User
    {
       public int ID { get; set; }
       public string PersonalIdentityNumber { get; set; }
       public string Name { get; set; }
       public int FirstName  { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }

        public User( int id, string personalIdentityNumber, string name)
        { 
        
            PersonalIdentityNumber = personalIdentityNumber;
            Name = name;
            ID = id;


        }
        //public User()
        //{

        //}
      



    }
}
