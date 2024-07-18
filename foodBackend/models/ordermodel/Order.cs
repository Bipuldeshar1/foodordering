namespace foodBackend.models.ordermodel
{
    public class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public DateTime OrderDate { get; set; }
        public List<orderItem> OrderItems { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } 
        public string Address { get; set; }
        public int PhoneNUmber { get; set; }
    }
}
