using ShopCaKoi.Repositores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface IOrderKoiService
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
