using EcommerceDotnet.Data;
using EcommerceDotnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceDotnet.Services
{
    public class ShopService : IShopService
    {
        private readonly EcommerceContext dbContext;

        public ShopService(EcommerceContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<ItemModel> cartItems = new List<ItemModel>();
        public List<ItemModel> ListItemsInShop()
        {
            return dbContext.Items.Where(x => x.IsPublished).ToList();
        }
		

		public List<ItemModel> AddToCart(int itemId)
        {
            var item = dbContext.Items.Find(itemId);
            if (item != null)
            {
                cartItems.Add(item);
            }
            return(cartItems);
        }

        public List<ItemModel> RemoveFromCart(int itemId)
        {
            var itemToRemove = cartItems.FirstOrDefault(item => item.Id == itemId);
            if (itemToRemove != null)
            {
                cartItems.Remove(itemToRemove);
            }
            return cartItems;
        }


        public void Checkout(List<CheckOutModel> itemIds)
        {
            var itemscheckout = dbContext.CheckoutItems.Where(item => item.Id == item.Id).ToList();
            dbContext.CheckoutItems.RemoveRange(itemscheckout);
            dbContext.SaveChanges();
        }

        public ItemModel ListItemInShop(int id)
        {
            return dbContext.Items.Find(id);
        }
        public ItemModel GetItem(int id)
        {
            return dbContext.Items.Find(id);
        }
		
	}
}
