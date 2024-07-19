using foodBackend.models.ordermodel;
using foodBackend.models;

namespace foodBackend.Dtos.order
{
    public class OrderViewModel
    {
        public int TotalPrice { get; set; }
        public string Address { get; set; }
        public int PhoneNUmber { get; set; }

        public List<OrderItemVm> OrderItems { get; set; }


    }

}
