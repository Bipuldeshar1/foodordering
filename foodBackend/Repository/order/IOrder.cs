using foodBackend.Dtos.order;
using foodBackend.models.ordermodel;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Repository.order
{
    public interface IOrder
    {
       Task<IActionResult> orderItem(OrderViewModel model);
    }
}
