using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.Data
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Booking
    {
        public int ID { get; set; }
        public string Dsc { get; set; }
        public int Status { get; set; }
        public DateTime Datum { get; set; }
        public int Company_ID { get; set; }
    }

    public class Result
    {
        public int CodeId { get; set; }
        public string Txt { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public string PersonalIdentityNumber { get; set; }
        public string Name { get; set; }
    }

    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string OpeningHours { get; set; }
        public string Picture { get; set; }
    }

    public class DsResponse2
    {
        public List<Booking> Booking { get; set; }
        public List<Result> Result { get; set; }
        public List<User> User { get; set; }
        public List<Company> Company { get; set; }
    }

    public class DsResponse
    {
        public DsResponse2 dsResponse { get; set; }
    }

    public class Response
    {
        public DsResponse dsResponse { get; set; }
    }

    public class Root
    {
        public Response response { get; set; }
    }


}
