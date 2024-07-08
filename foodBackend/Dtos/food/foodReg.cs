using foodBackend.models;

namespace foodBackend.Dtos.food
{
    public class foodReg
    {
       
        public string name { get; set; }
        public string description { get; set; }
        public IFormFile imageUrl { get; set; }
        public string price { get; set; }
        public string quantity { get; set; }
        public string address { get; set; }
        public bool outOfStock { get; set; }
        public string categoryName { get; set; }
    }
}
