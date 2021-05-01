namespace TravelRecord.Helpers
{
    public class Constants
    {
        public const string VENUE_SEARCH =
            "https://api.foursquare.com/v2/venues/search?ll={0},{1}&client_id={2}&client_secret={3}&v={4}";
        public const string CLIENT_ID = "3JHC4N4ZAQKYDDBZN5SIUMHVFUMXIZT0HOYH4RZFUKCUIOZD";
        public const string CLIENT_SECRET = "ASHSFLVT30NTINNH45NSHVROMOV5FWERRFGSRH2VVEOPZRH5";

        public const string VISITED_SAVE =
            "https://travelrecordwebapi.azurewebsites.net/api/Posts/?id=0&Experience={0}&VenueName={1}&CategoryId={2}&CategoryName={3}&Latitude={4}&Longitude={5}&Address={6}&Distance={7}";
        public const string VISITED_GET =
            "https://travelrecordwebapi.azurewebsites.net/api/Posts";
    }
}
