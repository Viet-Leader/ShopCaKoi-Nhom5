using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;

namespace ShopCaKoi.Repositores
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataShopCaKoiContext _dbContext;
        public CustomerRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCustomer(Customer infor)
        {
            try
            {
                _dbContext.Customers.Add(infor);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool CustomerExists(string id)
        {
            return _dbContext.Customers.Any(e => e.CustomerId == id);
        }

        public async Task<List<Customer>> GetCustomerWithDetailAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(string customerId)
        {
            return await _dbContext.Customers
                .FirstOrDefaultAsync(c => c.CustomerId == customerId);
        }

        public async Task<Boolean> UpdateCustomerAsync(Customer customer)
        {
            try
            {
                _dbContext.Customers.Update(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Boolean> DeleteCustomerAsync(string customerId)
        {
            var customer = await _dbContext.Customers.FindAsync(customerId);
            if (customer == null)
                return false;

            _dbContext.Customers.Remove(customer);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderKoi>> GetCustomerKoiOrdersAsync(string customerId)
        {
            return await _dbContext.OrderKois
                .Where(order => order.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<OrderTrip>> GetCustomerTripOrdersAsync(string customerId)
        {
            return await _dbContext.OrderTrips
                .Where(order => order.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<List<Feedback>> GetCustomerFeedbacksAsync(string customerId)
        {
            return await _dbContext.Feedbacks
                .Where(feedback => feedback.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
