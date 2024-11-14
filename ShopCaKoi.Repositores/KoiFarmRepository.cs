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
	public class KoiFarmRepository : IKoiFarmRepository
	{
		private readonly DataShopCaKoiContext _dbContext;
		public KoiFarmRepository(DataShopCaKoiContext dbContext)
		{
			_dbContext = dbContext;
		}

		public bool AddKoiFarm(KoiFarm infor)
		{
			try
			{
				_dbContext.KoiFarms.Add(infor);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException();
			}
		}

		public bool DelKoiFarm(KoiFarm infor)
		{
			try
			{
				_dbContext.KoiFarms.Remove(infor);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException(ex.ToString());
				return false;
			}

		}

		public bool DelKoiFarm(string id)
		{
			try
			{
				var ojbDel = _dbContext.KoiFarms.Where(p => p.FarmId.Equals(id)).FirstOrDefault();
				if (ojbDel != null)
				{
					_dbContext.KoiFarms.Remove(ojbDel);
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

		public async Task<KoiFarm> GetKoiFarmById(string id)
		{
			return await _dbContext.KoiFarms.Where(p => p.FarmId.Equals(id)).FirstOrDefaultAsync();
		}
		

		public async Task<List<KoiFarm>> GetKoiFarmsAsync()
		{
			return await _dbContext.KoiFarms.ToListAsync();
		}

		public bool KoiFarmExists(string id)
		{
			return _dbContext.KoiFarms.Any(e => e.FarmId == id);
		}

		public bool UpdKoiFarm(KoiFarm infor)
		{
			try
			{
				_dbContext.KoiFarms.Update(infor);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}

		}
       
    }
}

