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
		{
			return dbContext.Items.ToList();
		}

		public void ListAddToCart(ItemModel item)
		{
			dbContext.Items.Add(item);
			dbContext.SaveChanges();
		}

		public void ListRemoveCart(int itemId)
		{
			var itemToRemove = dbContext.Items.FirstOrDefault(item => item.Id == itemId);
			if (itemToRemove != null)
			{
				dbContext.Items.Remove(itemToRemove);
				dbContext.SaveChanges();
			}
		}

		public void ListCheckout(List<int> itemIds)
		{
			var itemsToRemove = dbContext.Items.Where(item => itemIds.Contains(item.Id)).ToList();
			dbContext.Items.RemoveRange(itemsToRemove);
			dbContext.SaveChanges();
		}
	}
}
