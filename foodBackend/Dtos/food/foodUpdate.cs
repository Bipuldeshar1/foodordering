using foodBackend.models;

namespace foodBackend.Dtos.food
{
    public class foodUpdate
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public IFormFile imageUrl { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public string address { get; set; }
        public bool outOfStock { get; set; }
        public string categoryId { get; set; }

    }
}
