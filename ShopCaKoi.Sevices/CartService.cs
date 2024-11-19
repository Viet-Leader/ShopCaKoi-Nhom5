using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores;
using ShopCaKoi.Sevices.Interfaces;
using ShopCaKoi.Repositores.Interfaces;

namespace ShopCaKoi.Sevices
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public void AddToCart(string customerId, string koiId, string tripId, decimal price, int quantity)
        {
            var cart = _repository.GetCartByCustomerId(customerId);

            if (cart == null)
            {
                _repository.CreateCart(customerId);
                cart = _repository.GetCartByCustomerId(customerId);
            }

            var newItem = new CartItem
            {
                CartItemId = Guid.NewGuid().ToString(),
                CartId = cart.CartId,
                KoiId = koiId,
                TripId = tripId,
                Price = price,
                Quantity = quantity,
                Total = price * quantity
            };

            _repository.AddItemToCart(cart.CartId, newItem);
        }

        public void UpdateCartItem(string cartId, string cartItemId, int quantity)
        {
            _repository.UpdateItemQuantity(cartId, cartItemId, quantity);
        }


        public Cart GetCartDetails(string customerId)
        {
            return _repository.GetCartByCustomerId(customerId);
        }

       public void RemoveItemFromCart(string cartItemId)
        {
            _repository.RemoveItemFromCart(cartItemId);
        }

       
    }
}
