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
    public class CartRepository : ICartRepository
    {
        private readonly DataShopCaKoiContext _dbContext;

        public CartRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Cart GetCartByCustomerId(string customerId)
        {
            var cart = _dbContext.Carts
                         .Where(c => c.CustomerId == customerId)
                         .Include(c => c.CartItems) // Bao gồm các CartItems trong giỏ
                         .ThenInclude(ci => ci.Koi) // Bao gồm thông tin Koi nếu có
                         .Include(c => c.CartItems) // Bao gồm CartItems lần nữa để lấy thông tin Trip
                         .ThenInclude(ci => ci.Trip) // Bao gồm thông tin Trip nếu có
                         .ThenInclude(t => t.Farm) // Bao gồm thông tin Farm từ Trip
                         .FirstOrDefault(); // Lấy giỏ hàng đầu tiên hoặc null nếu không có giỏ hàng
            return cart;
        }


        public void AddItemToCart(string cartId, CartItem item)
        {
            var cart = _dbContext.Carts.Include(c => c.CartItems).FirstOrDefault(c => c.CartId == cartId);
            if (cart != null)
            {
                cart.CartItems.Add(item);
                _dbContext.SaveChanges();
            }
        }

        public void UpdateItemQuantity(string cartId, string cartItemId, int quantity)
        {
            var cartItem = _dbContext.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId && ci.CartId == cartId);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                cartItem.Total = cartItem.Price * quantity;
                _dbContext.SaveChanges();
            }
        }

        // Xóa sản phẩm khỏi giỏ hàng
      /*  public async Task<bool> RemoveItemFromCart(string id)
        {
            try
            {
                var ojbDel = await _dbContext.Carts.FirstOrDefaultAsync(p => p.CartId == id);
                if (ojbDel != null)
                {
                    _dbContext.Carts.Remove(ojbDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }*/
        public void RemoveItemFromCart(string cartItemId)
        {
            // Tìm kiếm item trong CartItems theo cartItemId
            var item = _dbContext.CartItems.FirstOrDefault(c => c.CartItemId == cartItemId);

            // Nếu tìm thấy item, thực hiện xóa
            if (item != null)
            {
                _dbContext.CartItems.Remove(item);  // Xóa item khỏi cơ sở dữ liệu
                _dbContext.SaveChanges();  // Lưu thay đổi vào cơ sở dữ liệu
            }
            else
            {
                // Nếu không tìm thấy item, ném ra exception để thông báo
                throw new Exception("Item not found in the cart.");
            }
        }

        // Tạo giỏ hàng mới cho khách hàng
        public void CreateCart(string customerId)
        {
            var cart = new Cart
            {
                CartId = Guid.NewGuid().ToString(),
                CustomerId = customerId
            };
            _dbContext.Carts.Add(cart);
            _dbContext.SaveChanges();
        }
    }
}
