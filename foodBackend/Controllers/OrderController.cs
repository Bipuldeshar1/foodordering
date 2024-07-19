using foodBackend.Dtos.auth;
using foodBackend.Dtos.order;
using foodBackend.models.ordermodel;
using foodBackend.Repository.auth;
using foodBackend.Repository.order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace foodBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrder order;

        public OrderController(IOrder order)
        {
            this.order = order;
        }

        [HttpPost("order")]
        public Task<IActionResult> orderItem([FromForm]OrderViewModel model)
        {
            return order.orderItem(model);
        }

    }
}
