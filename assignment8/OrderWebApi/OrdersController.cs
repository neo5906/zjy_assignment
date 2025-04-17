using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq;
using OrderService;
using System;

namespace OrderWebApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly OrderService _orderService;

        public OrdersController(string connectionString)
        {
            _orderService = new OrderService(connectionString);
        }

        // GET: api/orders  
        [Route]
        public async Task<IHttpActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrdersAsync();
                return Json(orders);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/orders/5  
        [Route("{orderId}")]
        public async Task<IHttpActionResult> GetOrderById(string orderId)
        {
            try
            {
                var order = await _orderService.GetOrdersByOrderIdAsync(orderId).FirstOrDefaultAsync();
                if (order == null)
                {
                    return Content(HttpStatusCode.NotFound, "订单不存在");
                }
                return Json(order);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/orders  
        [Route]
        public async Task<IHttpActionResult> AddOrder(Order order)
        {
            try
            {
                await _orderService.AddOrderAsync(order);
                return Content(HttpStatusCode.Created, "订单创建成功");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/orders/5  
        [Route("{orderId}")]
        public async Task<IHttpActionResult> UpdateOrder(string orderId, Order order)
        {
            try
            {
                if (orderId != order.OrderId)
                {
                    return Content(HttpStatusCode.BadRequest, "订单号不匹配");
                }
                await _orderService.UpdateOrderAsync(order);
                return Content(HttpStatusCode.OK, "订单更新成功");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/orders/5  
        [Route("{orderId}")]
        public async Task<IHttpActionResult> DeleteOrder(string orderId)
        {
            try
            {
                await _orderService.RemoveOrderAsync(orderId);
                return Content(HttpStatusCode.OK, "订单删除成功");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // GET: api/orders/details/5  
        [Route("details/{goodsName}")]
        public async Task<IHttpActionResult> GetOrderByGoodsName(string goodsName)
        {
            try
            {
                var orders = await _orderService.GetOrdersByGoodsNameAsync(goodsName);
                return Json(orders);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}