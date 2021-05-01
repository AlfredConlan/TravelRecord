namespace TravelRecord.Model
{
    public class Visited
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
