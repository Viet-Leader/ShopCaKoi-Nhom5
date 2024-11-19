using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface ICartService
    {
        // Các phương thức nghiệp vụ xử lý giỏ hàng
        void AddToCart(string customerId, string koiId, string tripId, decimal price, int quantity);
        void UpdateCartItem(string cartId, string cartItemId, int quantity);
        void RemoveItemFromCart(string cartItemId);
        Cart GetCartDetails(string customerId);
    }
}
