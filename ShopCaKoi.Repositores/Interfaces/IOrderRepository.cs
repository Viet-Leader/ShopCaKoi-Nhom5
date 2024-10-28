using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderKoi>> GetAllOrders();
        Task<OrderKoi> GetOrderById(string orderId);
        Task<bool> AddOrder(OrderKoi order);
        Task<bool> UpdateOrder(OrderKoi order);
        Task<bool> DeleteOrder(OrderKoi order);
        Task<bool> DeleteOrder(string orderId);
        Task<bool> UpdatePaymentStatus(string orderId, string paymentStatus);
        bool OrderExists(string orderId);
    }
}
