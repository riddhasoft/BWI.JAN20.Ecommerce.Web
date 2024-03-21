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

		public List<ItemModel> ListItemsInShop()
		{//is published=ture
			return dbContext.Items.ToList();
		}
        public ItemModel ListItemInShop(int id)
        {
            return dbContext.Items.Find(id);
        }
        public void AddToCart(CheckOutModel items)
		{
			dbContext.CheckoutItems.Add(items);
			dbContext.SaveChanges();
		}

		public void RemoveFromCart(int itemId)
		{
			var itemToRemove = dbContext.CheckoutItems.FirstOrDefault(item => item.Id == itemId);
			if (itemToRemove != null)
			{
				dbContext.CheckoutItems.Remove(itemToRemove);
				dbContext.SaveChanges();
			}
		}


		public void Checkout(List<CheckOutModel> itemIds)
		{
			var itemscheckout=dbContext.CheckoutItems.Where(item=>item.Id==item.Id).ToList();
			dbContext.CheckoutItems.RemoveRange(itemscheckout); 
			dbContext.SaveChanges();
		}

     
    }
}
