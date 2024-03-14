using BWI.JAN20.Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWI.JAN20.Ecommerce.Service
{
    public interface IShopService
    {
        List<ItemModel> ListItemsInShop();

       
    }
}
