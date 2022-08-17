namespace RestaurantsAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
    }
}
