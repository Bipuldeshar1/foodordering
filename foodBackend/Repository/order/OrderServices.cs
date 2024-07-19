using foodBackend.Dtos.order;
using foodBackend.models.ordermodel;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.order
{
    public class OrderServices : IOrder
    {
        public Task<IActionResult> orderItem(OrderViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
