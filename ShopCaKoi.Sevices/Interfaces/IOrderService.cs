using ShopCaKoi.Repositores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface IOrderService
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
