using Newtonsoft.Json;
using SwedishCareAb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SwedishCareAb.Data
{
    public class TestServer
    {

        private static string baseAPIUrl = "http://localhost:8810/TestServer/rest/TestServerService/getbooking/?cPNRP=";


        public class ClientResponse
        {
            public SwedishCareAb.Models.User user { get; set; }

            public List<SwedishCareAb.Models.Booking> bookings { get; set; }

            public List<SwedishCareAb.Models.Company> companies { get; set; }



        }

        public static async Task<ClientResponse> GetBooking(string pnr)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPIUrl + pnr);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("");
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();

                    string test = httpResponseBody;

                    var root = JsonConvert.DeserializeObject<Data.Root>(httpResponseBody);

                    /* TODO: Kontroll av Result-tt så att patienten hittas */

                    ClientResponse res = new ClientResponse();
                    res.user = null;
                    if (root.response.dsResponse.dsResponse.User != null)
                    {
                        Data.User datauser = root.response.dsResponse.dsResponse.User.First();
                        res.user = new Models.User(datauser.ID, datauser.PersonalIdentityNumber, datauser.Name);
                    } else
                    {
                        return null;
                    }





                    /* TODO: Samma som för user för booking och companies */

                    res.companies = new List<Models.Company>();
                    if (root.response.dsResponse.dsResponse.Company != null)
                    {
                        foreach (var datacompany in root.response.dsResponse.dsResponse.Company)
                        {
                            Models.Company newComp = new Models.Company();
                            newComp.Address = datacompany.Address;
                            newComp.ID = datacompany.ID;
                            /* TODO Resten */

                            res.companies.Add(newComp);
                        }

                        //List<Data.Booking> databookings = 
                    }




                    res.bookings = new List<Models.Booking>();
                    if (root.response.dsResponse.dsResponse.Booking != null)
                    {
                        foreach (var databooking in root.response.dsResponse.dsResponse.Booking)
                        {
                            Models.Booking newBooking = new Models.Booking();
                            newBooking.Company = res.companies.FirstOrDefault(x => x.ID == databooking.Company_ID);
                            newBooking.Date = databooking.Datum;
                            newBooking.Description = databooking.Dsc;
                            /* Todo Resten */
                            res.bookings.Add(newBooking);
                        }

                        //List<Data.Booking> databookings = 
                    }




                    return res;
                }
            }
            return null;
        }

    }
}
