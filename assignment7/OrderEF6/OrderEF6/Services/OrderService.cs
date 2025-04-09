using System;
using System.Data.Entity;
using System.Linq;
using OrderEF6.Data;
using OrderEF6.Models;

namespace OrderEF6.Services
{
    public class OrderService : IDisposable
    {
        private readonly OrderContext _context = new OrderContext();

        public void AddOrder(Order order)
        {
            if (_context.Orders.Any(o => o.OrderId == order.OrderId))
                throw new InvalidOperationException("订单已存在");

            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var existing = _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == updatedOrder.OrderId);

            if (existing == null)
                throw new KeyNotFoundException("订单不存在");

            // 更新主订单
            _context.Entry(existing).CurrentValues.SetValues(updatedOrder);

            // 删除不再存在的明细
            foreach (var detail in existing.Details.ToList())
            {
                if (!updatedOrder.Details.Any(d =>
                    d.OrderId == detail.OrderId &&
                    d.ProductName == detail.ProductName))
                {
                    _context.OrderDetails.Remove(detail);
                }
            }

            // 更新或添加明细
            foreach (var detail in updatedOrder.Details)
            {
                var existingDetail = existing.Details
                    .FirstOrDefault(d =>
                        d.OrderId == detail.OrderId &&
                        d.ProductName == detail.ProductName);

                if (existingDetail != null)
                {
                    _context.Entry(existingDetail).CurrentValues.SetValues(detail);
                }
                else
                {
                    existing.Details.Add(detail);
                }
            }

            _context.SaveChanges();
        }

        public void DeleteOrder(string orderId)
        {
            var order = _context.Orders
                .Include(o => o.Details)
                .FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
                throw new KeyNotFoundException("订单不存在");

            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public IQueryable<Order> QueryOrders()
        {
            return _context.Orders
                .Include(o => o.Details)
                .OrderBy(o => o.TotalAmount);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
