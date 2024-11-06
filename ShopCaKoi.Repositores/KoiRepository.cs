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
	public class KoiRepository : IKoiRepository
	{
		private readonly DataShopCaKoiContext _dbContext;
		public KoiRepository(DataShopCaKoiContext dbContext)
		{
			_dbContext = dbContext;
		}

		public bool AddKoi(Koi infor)
		{
			try
			{
				_dbContext.Kois.Add(infor);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException();
			}
		}

		public bool DelKoi(Koi infor)
		{
			try
			{
				_dbContext.Kois.Remove(infor);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				throw new NotImplementedException(ex.ToString());
				return false;
			}

		}

		public bool DelKoi(string id)
		{
			try
			{
				var ojbDel = _dbContext.Kois.Where(p => p.KoiId.Equals(id)).FirstOrDefault();
				if (ojbDel != null)
				{
					_dbContext.Kois.Remove(ojbDel);
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

		public async Task<Koi> GetKoiById(string id)
		{
			return await _dbContext.Kois.Where(p => p.KoiId.Equals(id)).FirstOrDefaultAsync();
		}

		public async Task<List<Koi>> GetKoisAsync()
		{
			return await _dbContext.Kois.ToListAsync();
		}

		public bool KoiExists(string id)
		{
			return _dbContext.Kois.Any(e => e.KoiId == id);
		}

		public bool UpdKoi(Koi infor)
		{
			try
			{
				_dbContext.Kois.Update(infor);
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
