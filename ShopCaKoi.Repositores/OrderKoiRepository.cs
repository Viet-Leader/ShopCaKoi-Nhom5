using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;


namespace ShopCaKoi.Repositores
{
    public class OrderKoiRepository : IOrderKoiRepository
    {
        private readonly DataShopCaKoiContext _dbContext;

        public OrderKoiRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OrderKoi>> GetAllOrders()
        {
            return await _dbContext.OrderKois.Include(o => o.Customer)
                .Include(o => o.Koi) // Include Koi details
                .Include(o => o.Quotation).ToListAsync();

        }

        public async Task<OrderKoi> GetOrderById(string orderId)
        {
            return await _dbContext.OrderKois.Where(p => p.OrderId.Equals(orderId)).FirstOrDefaultAsync();
        }

        public bool AddOrder(OrderKoi order)
        {
            try
            {
                _dbContext.OrderKois.Add(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool UpdateOrder(OrderKoi order)
        {
            try
            {
                _dbContext.OrderKois.Update(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteOrder(OrderKoi order)
        {
            try
            {
                _dbContext.OrderKois.Remove(order);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public bool DeleteOrder(string orderId)
        {
            try
            {
                var ojbDel = _dbContext.OrderKois.Where(p => p.OrderId.Equals(orderId)).FirstOrDefault();
                if (ojbDel != null)
                {
                    _dbContext.OrderKois.Remove(ojbDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public bool UpdatePaymentStatus(OrderKoi orderId)
        {
            try
            {
                _dbContext.OrderKois.Update(orderId);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool OrderExists(string id)
        {
            return _dbContext.OrderKois.Any(e => e.OrderId == id);
        }
        public async Task<double> CalculateTotalPrice(OrderKoi order)
        {
            var orderDetails = await _dbContext.OrderKois
                .FirstOrDefaultAsync(o => o.OrderId == order.OrderId);

            if (orderDetails != null)
            {
                return (double)orderDetails.Koi.Price * (double)orderDetails.Quantity;
            }

            return 0.0; // Trả về 0 nếu không tìm thấy đơn hàng
        }

    }
}
