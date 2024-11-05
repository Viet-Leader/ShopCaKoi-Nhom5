using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Sevices
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }
        public bool AddCustomer(Customer infor)
        {
            return _repository.AddCustomer(infor);
        }

        public Task<bool> CustomerExists(string id, string email)
        {
            return _repository.CustomerExists(id,email);
        }

        public Task<List<Customer>> GetCustomerWithDetailAsync()
        {
            return _repository.GetCustomerWithDetailAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(string customerId)
        {
            return await _repository.GetCustomerByIdAsync(customerId);
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            return await _repository.UpdateCustomerAsync(customer);
        }

        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            return await _repository.DeleteCustomerAsync(customerId);
        }

        public async Task<List<OrderKoi>> GetCustomerKoiOrdersAsync(string customerId)
        {
            return await _repository.GetCustomerKoiOrdersAsync(customerId);
        }

        public async Task<List<OrderTrip>> GetCustomerTripOrdersAsync(string customerId)
        {
            return await _repository.GetCustomerTripOrdersAsync(customerId);
        }

        public async Task<List<Feedback>> GetCustomerFeedbacksAsync(string customerId)
        {
            return await _repository.GetCustomerFeedbacksAsync(customerId);
        }

		public Task<Customer?> GetCustomerByEmail(string email)
		{
			return _repository.GetCustomerByEmail(email);
		}

		public Task<bool> ValidateCustomerLogin(string email, string password)
		{
			return _repository.ValidateCustomerLogin(email, password);
		}
	}
}
