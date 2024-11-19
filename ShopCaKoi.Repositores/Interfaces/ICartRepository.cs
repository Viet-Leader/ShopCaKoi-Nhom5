using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface ICartRepository
    {
        Cart GetCartByCustomerId(string customerId);
        void AddItemToCart(string cartId, CartItem item);
        void UpdateItemQuantity(string cartId, string cartItemId, int quantity);
        void RemoveItemFromCart(string cartItemId);
        void CreateCart(string customerId);

    }
}

