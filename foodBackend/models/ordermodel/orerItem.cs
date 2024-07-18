namespace foodBackend.models.ordermodel
{
    public class orderItem
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public foodModel foodModel { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }
}
