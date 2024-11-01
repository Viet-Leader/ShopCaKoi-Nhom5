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

		public bool CustomerExists(string id)
		{
			return _repository.CustomerExists(id);
		}

		public Task<List<Customer>> GetCustomerWithDetailAsync()
		{
			return _repository.GetCustomerWithDetailAsync();
		}
	}
}
