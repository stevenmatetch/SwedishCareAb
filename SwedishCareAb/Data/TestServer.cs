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
        private static string baseAPIUrlRegister = "http://localhost:8810/TestServer/rest/TestServerService/register/?BookingId=";


        //public class ClientResponse
        //{
           
        //}

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

                    res.companies = new List<Models.Company>();
                    if (root.response.dsResponse.dsResponse.Company != null)
                    {
                        foreach (var datacompany in root.response.dsResponse.dsResponse.Company)
                        {
                            Models.Company newComp = new Models.Company();
                            newComp.Address = datacompany.Address;
                            newComp.ID = datacompany.ID;
                            newComp.Mail = datacompany.Mail;
                            newComp.OpeningHours = datacompany.OpeningHours;
                            newComp.PhoneNumber = datacompany.PhoneNumber;
                            newComp.Picture = datacompany.Picture;
                            newComp.Name = datacompany.Name;
                            

                            res.companies.Add(newComp);
                        }

                      
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
                            newBooking.Status = databooking.Status;
                            newBooking.ID = databooking.ID;
                            
                          
                            res.bookings.Add(newBooking);
                        }

                    }


                    return res;
                }
            }
            return null;
        }


        public static async Task<bool> Register(int bookingid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAPIUrlRegister + bookingid.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("");
                string httpResponseBody = "";
                if (response.IsSuccessStatusCode)
                {
                    httpResponseBody = await response.Content.ReadAsStringAsync();
                    return true;
                }
            }
            return false;
        }


    }
}
