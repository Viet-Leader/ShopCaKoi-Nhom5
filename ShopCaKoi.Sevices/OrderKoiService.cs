using System.Collections.Generic;
using System.Threading.Tasks;
using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Services
{
    public class OrderKoiService : IOrderKoiService
    {
        private readonly IOrderKoiRepository _orderKoiRepository;

        public OrderKoiService(IOrderKoiRepository orderKoiRepository)
        {
            _orderKoiRepository = orderKoiRepository;
        }

        public async Task<List<OrderKoi>> GetAllOrders()
        {
            return await _orderKoiRepository.GetAllOrders();
        }

        public async Task<OrderKoi> GetOrderById(string orderId)
        {
            return await _orderKoiRepository.GetOrderById(orderId);
        }

        public bool AddOrder(OrderKoi order)
        {
            return _orderKoiRepository.AddOrder(order);
        }

        public bool UpdateOrder(OrderKoi order)
        {
            return _orderKoiRepository.UpdateOrder(order);
        }

        public bool DeleteOrder(OrderKoi order)
        {
            return _orderKoiRepository.DeleteOrder(order);
        }

        public bool DeleteOrder(string orderId)
        {
            return _orderKoiRepository.DeleteOrder(orderId);
        }

        public bool UpdatePaymentStatus(OrderKoi orderId)
        {
            return _orderKoiRepository.UpdatePaymentStatus(orderId);
        }

        public bool OrderExists(string orderId)
        {
            return _orderKoiRepository.OrderExists(orderId);
        }

        public async Task<double> CalculateTotalPrice(OrderKoi order)
        {
            return await _orderKoiRepository.CalculateTotalPrice(order);
        }

    }
}
