namespace RestaurantsAPI.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
    }
}
