using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface IOrderKoiRepository
    {
        Task<List<OrderKoi>> GetAllOrders();
        Task<OrderKoi> GetOrderById(string orderId);
        Boolean AddOrder(OrderKoi order);
        Boolean UpdateOrder(OrderKoi order);
        Boolean DeleteOrder(OrderKoi order);
        Boolean DeleteOrder(string orderId);
        Boolean UpdatePaymentStatus(OrderKoi orderId);
        Task<double> CalculateTotalPrice(OrderKoi order);
        bool OrderExists(string orderId);
    }
}
