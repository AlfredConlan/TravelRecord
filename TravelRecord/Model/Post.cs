using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TravelRecord.Helpers;

namespace TravelRecord.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string Experience { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public int Distance { get; set; }

    }
}
