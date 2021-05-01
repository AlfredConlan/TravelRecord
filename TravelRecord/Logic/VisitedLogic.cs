using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using static TravelRecord.Model.Visited;

namespace TravelRecord.Logic
{
    public class VisitedLogic
    {
        public async static Task<string> SavePost(string experience,
                                                    string venuename,
                                                    string categoryid,
                                                    string categoryname,
                                                    string latitude,
                                                    string longitude,
                                                    string address,
                                                    string distance)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://travelrecordwebapi.azurewebsites.net/api/Posts"))
                {
                    var post = new Visited();
                    post.Experience = experience;
                    post.VenueName = venuename;
                    post.CategoryId = categoryid;
                    post.CategoryName = categoryname;
                    post.Latitude = Convert.ToDouble(latitude);
                    post.Longitude = Convert.ToDouble(longitude);
                    post.Address = address;
                    post.Distance = Convert.ToInt32(distance);

                    var response = await httpClient.PostAsJsonAsync(request.RequestUri, post);

                    return response.ToString();
                }
            }
        }


        public async static Task<List<Visited>> RetrievePost()
        {
            List<Visited> post = new List<Visited>();

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://travelrecordwebapi.azurewebsites.net/api/Posts"))
                {
                    HttpResponseMessage response = await httpClient.GetAsync(request.RequestUri);

                    if (response.IsSuccessStatusCode)
                    {
                        var json = await response.Content.ReadAsStringAsync();

                        var postRoot = JsonConvert.DeserializeObject<List<TravelRecord.Model.Visited>>(json);

                        return post = postRoot as List<Visited>;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

    }
}


