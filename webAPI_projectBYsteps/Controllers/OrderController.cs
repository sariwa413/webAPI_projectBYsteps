using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace webAPI_projectBYsteps.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class OrdersController : ControllerBase
        {
            IOrderService _orderService;
            IMapper _mapper;
            public OrdersController(IOrderService orderService, IMapper mapper)
            {
                _orderService = orderService;
                _mapper = mapper;
            }

            // POST api/<AuthController>
            [HttpPost]

            public async Task<ActionResult<orderDTO>> Order([FromBody] orderDTO orderDTO )
            {
                Order order = _mapper.Map<orderDTO, Order>(orderDTO);
                Order newOrder = await _orderService.AddOrder(order);
                if (newOrder != null)
                {
                    orderDTO orderToReturn = _mapper.Map<Order, orderDTO>(newOrder);
                    return Ok(orderToReturn);
                }
                return null;
            }

    }
}
