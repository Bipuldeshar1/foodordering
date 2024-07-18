using System.ComponentModel.DataAnnotations.Schema;

namespace foodBackend.models.ordermodel
{
    public class orderItem
    {
        public string Id { get; set; }

        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string FoodId { get; set; }
       
        public foodModel foodModel { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
