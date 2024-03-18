using EcommerceDotnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDotnet.Services
{
	public interface IShopService
	{
		List<ItemModel> ListItemsInShop();

	}
}
