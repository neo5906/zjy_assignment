using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment5
{
    public class Order
    {
        public int OrderID { get; set; } 
        public List<OrderDetails> OrderDetails { get; set; }

        public Order(int orderid)
        {
            OrderID = orderid;
            OrderDetails = new List<OrderDetails>();
        }

        public override string ToString()
        {
            return $"订单号: {OrderID} ";
        }

        public override bool Equals(object obj)
        {
            return obj is Order order && OrderID == order.OrderID;
        }

        public override int GetHashCode()
        {
            return OrderID.GetHashCode();
        }
        public double TotalAmount => OrderDetails.Sum(od => od.Amount);
    }
    public class OrderDetails 
    {
       public string ProductName { get; set; }
        public string Customer { get; set; }
        public double Amount { get; set; }
        public OrderDetails(string productName, string customer,double amount)
        {
            ProductName = productName;
            Customer = customer;
            Amount = amount;           
        }
        public override string ToString()
        {
            return $"{ProductName}, 客户: {Customer}, 金额: {Amount}";
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetails details && ProductName == details.ProductName && Customer == details.Customer && Amount == details.Amount;
        }

        public override int GetHashCode()
        {
            return (ProductName, Customer, Amount).GetHashCode();
        }
    }
    public class OrderService
    {
        private List<Order> Orders { get; set; } = new List<Order>();
        public void AddOrder(Order order)
        {
            if (Orders.Contains(order))
                throw new InvalidOperationException("Order already exists.");
            Orders.Add(order);
        }
        public void DeleteOrder(int orderId)
        {
            var orderToRemove = Orders.FirstOrDefault(o => o.OrderID == orderId);
            if (orderToRemove == null)
                throw new InvalidOperationException("Order not found.");
            Orders.Remove(orderToRemove);
        }
        public void UpdateOrder(Order updatedOrder)
        {
            var existingOrder = Orders.FirstOrDefault(o => o.OrderID == updatedOrder.OrderID);
            if (existingOrder == null)
                throw new InvalidOperationException("Order not found.");
            existingOrder.OrderDetails = updatedOrder.OrderDetails;
        }
        public List<Order> QueryOrders(string query)
        {
            var results = Orders.Where(o =>  o.OrderDetails.Any(od => od.ProductName.Contains(query)||od.Customer.Contains(query) )).OrderBy(o => o.TotalAmount).ToList();
            return results;
        }

        public void SortOrders(Func<Order, object> orderByFunc)
        {
            Orders = Orders.OrderBy(orderByFunc).ToList();
        }
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            OrderService orderService = new OrderService();

            // 添加订单  
            try
            {
                Order order1 = new Order(1);
                order1.OrderDetails.Add(new OrderDetails("Item1", "Alice", 150));
                orderService.AddOrder(order1);

                Console.WriteLine("Order added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 查询订单  
            var searchResults = orderService.QueryOrders("Alice");
            foreach (var order in searchResults)
            {
                Console.WriteLine(order);
            }

            // 更新订单  
            try
            {
                Order orderToUpdate = new Order(1);
                orderToUpdate.OrderDetails.Add(new OrderDetails("Item1", "Alice Updated", 150));
                orderService.UpdateOrder(orderToUpdate);
                Console.WriteLine("Order updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // 删除订单  
            try
            {
                orderService.DeleteOrder(1);
                Console.WriteLine("Order deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
    }
}
