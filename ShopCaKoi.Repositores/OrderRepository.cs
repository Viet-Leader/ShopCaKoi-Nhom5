using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;

namespace ShopCaKoi.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private List<OrderKoi> _orders = new List<OrderKoi>();

        public async Task<List<OrderKoi>> GetAllOrders()
        {
            return await Task.FromResult(_orders);
        }

        public async Task<OrderKoi> GetOrderById(string orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            return await Task.FromResult(order);
        }

        public async Task<bool> AddOrder(OrderKoi order)
        {
            if (OrderExists(order.OrderId)) return false;
            _orders.Add(order);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateOrder(OrderKoi order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder == null) return false;
            _orders[_orders.IndexOf(existingOrder)] = order;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteOrder(OrderKoi order)
        {
            var result = _orders.Remove(order);
            return await Task.FromResult(result);
        }

        public async Task<bool> DeleteOrder(string orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) return false;
            _orders.Remove(order);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePaymentStatus(string orderId, string paymentStatus)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null) return false;
            order.PaymentStatus = paymentStatus;
            return await Task.FromResult(true);
        }

        public bool OrderExists(string orderId)
        {
            return _orders.Any(o => o.OrderId == orderId);
        }
    }
}
