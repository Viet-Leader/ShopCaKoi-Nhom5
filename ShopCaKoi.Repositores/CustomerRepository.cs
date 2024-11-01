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
	}
}
