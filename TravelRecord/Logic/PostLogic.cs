using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Model;
using static TravelRecord.Model.Post;

namespace TravelRecord.Logic
{
    public class PostLogic
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
                    var post = new Post();
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

    }
}
