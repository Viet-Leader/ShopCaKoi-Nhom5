using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderKoi>> GetAllOrders()
        {
            return await _orderRepository.GetAllOrders();
        }

        public async Task<OrderKoi> GetOrderById(string orderId)
        {
            return await _orderRepository.GetOrderById(orderId);
        }

        public async Task<bool> AddOrder(OrderKoi order)
        {
            return await _orderRepository.AddOrder(order);
        }

        public async Task<bool> UpdateOrder(OrderKoi order)
        {
            return await _orderRepository.UpdateOrder(order);
        }

        public async Task<bool> DeleteOrder(OrderKoi order)
        {
            return await _orderRepository.DeleteOrder(order);
        }

        public async Task<bool> DeleteOrder(string orderId)
        {
            return await _orderRepository.DeleteOrder(orderId);
        }

        public async Task<bool> UpdatePaymentStatus(string orderId, string paymentStatus)
        {
            return await _orderRepository.UpdatePaymentStatus(orderId, paymentStatus);
        }

        public bool OrderExists(string orderId)
        {
            return _orderRepository.OrderExists(orderId);
        }
    }
}
