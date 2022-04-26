using Admin.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repos
{
     public class CartRepository:AdminRepo<Cart>
    {
        public CartRepository(DbContext _context) : base(_context) { }
        public void emptyCart(Cart c)
        {
            c.CartProducts.Clear();
        }
        public void addToCart(Cart cart,CartProduct cartProduct)
        {
            CartProduct toBeInserted = cart.CartProducts.Where(c => c.ProductId == cartProduct.ProductId).FirstOrDefault();
            if(toBeInserted!=null)
            {
                toBeInserted.Quantity += cartProduct.Quantity;
            }
            else
            {
                cart.CartProducts.Add(cartProduct);
            }
        }
        public Cart getCart()
        {
            return table.FirstOrDefault();
        }
    }
}
