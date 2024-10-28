using ShopCaKoi.Repositores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
namespace ShopCaKoi.Repositores
{
    public class OrderRepository : IOrderRepository
    {
        private readonly List<OrderKoi> _orders;

        public OrderRepository()
        {
            _orders = new List<OrderKoi>(); // Giả định danh sách đơn hàng trong bộ nhớ
        }

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
            if (OrderExists(order.OrderId))
                return false;

            _orders.Add(order);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateOrder(OrderKoi order)
        {
            var existingOrder = _orders.FirstOrDefault(o => o.OrderId == order.OrderId);
            if (existingOrder == null)
                return await Task.FromResult(false);

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.QuotationId = order.QuotationId;
            existingOrder.PaymentStatus = order.PaymentStatus;
            existingOrder.OrderDate = order.OrderDate;
            existingOrder.KoiId = order.KoiId;
            existingOrder.Quantity = order.Quantity;
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteOrder(OrderKoi order)
        {
            return await Task.FromResult(_orders.Remove(order));
        }

        public async Task<bool> DeleteOrder(string orderId)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                return await Task.FromResult(false);

            _orders.Remove(order);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePaymentStatus(string orderId, string paymentStatus)
        {
            var order = _orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
                return await Task.FromResult(false);

            order.PaymentStatus = paymentStatus;
            return await Task.FromResult(true);
        }

        public bool OrderExists(string orderId)
        {
            return _orders.Any(o => o.OrderId == orderId);
        }
    }
}

