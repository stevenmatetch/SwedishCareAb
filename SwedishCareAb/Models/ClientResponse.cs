using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.Models
{
    public class ClientResponse
    {
        public SwedishCareAb.Models.User user { get; set; }

        public List<SwedishCareAb.Models.Booking> bookings { get; set; }

        public List<SwedishCareAb.Models.Company> companies { get; set; }

    }
}
