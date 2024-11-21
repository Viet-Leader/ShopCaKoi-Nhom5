using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;

namespace ShopCaKoi.Repositores
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DataShopCaKoiContext _dbContext;
        public FeedbackRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddFeedback(Feedback infor)
        {
            try
            {
                _dbContext.Feedbacks.Add(infor);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Đã xảy ra lỗi: {ex.Message}");

                return false;
            }
        }
    }
}
