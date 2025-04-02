using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace OrderManagement
{
    public class OrderDetails : IEquatable<OrderDetails>
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total => UnitPrice * Quantity;

        public bool Equals(OrderDetails other) =>
            ProductName == other?.ProductName &&
            UnitPrice == other.UnitPrice;

        public override bool Equals(object obj) => Equals(obj as OrderDetails);
        public override int GetHashCode() => HashCode.Combine(ProductName, UnitPrice);

        public override string ToString() =>
            $"{ProductName} | 单价：{UnitPrice:C} | 数量：{Quantity} | 小计：{Total:C}";
    }

    public class Order : IEquatable<Order>
    {
        public string OrderId { get; }
        public string Customer { get; set; }
        public List<OrderDetails> Details { get; } = new List<OrderDetails>();
        public decimal TotalAmount => Details.Sum(d => d.Total);

        public Order(string orderId, string customer)
        {
            OrderId = orderId ?? throw new ArgumentNullException(nameof(orderId));
            Customer = customer ?? throw new ArgumentNullException(nameof(customer));
        }

        public bool Equals(Order other) => OrderId == other?.OrderId;
        public override bool Equals(object obj) => Equals(obj as Order);
        public override int GetHashCode() => OrderId.GetHashCode();

        public override string ToString() =>
            $"订单号：{OrderId}\n客户：{Customer}\n" +
            $"明细：\n{string.Join("\n", Details)}\n" +
            $"总金额：{TotalAmount:C}\n";
    }

    public class OrderService
    {
        public BindingList<Order> Orders { get; } = new BindingList<Order>();

        public void AddOrder(Order order)
        {
            if (Orders.Any(o => o.Equals(order)))
                throw new ArgumentException("订单已存在");

            foreach (var detail in order.Details)
                if (order.Details.Count(d => d.Equals(detail)) > 1)
                    throw new ArgumentException("存在重复订单明细");

            Orders.Add(order);
        }

        public void RemoveOrder(string orderId)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId)
                ?? throw new KeyNotFoundException("订单不存在");
            Orders.Remove(order);
        }

        public void UpdateOrder(Order updatedOrder)
        {
            var index = Orders.IndexOf(Orders.First(o => o.OrderId == updatedOrder.OrderId));
            if (index == -1)
                throw new KeyNotFoundException("订单不存在");

            if (Orders.Any(o => o != Orders[index] && o.Equals(updatedOrder)))
                throw new ArgumentException("订单号冲突");

            Orders[index] = updatedOrder;
        }

        public BindingList<Order> QueryOrders(Func<Order, bool> predicate) =>
            new BindingList<Order>(Orders.Where(predicate)
                .OrderBy(o => o.TotalAmount)
                .ToList());
    }
}