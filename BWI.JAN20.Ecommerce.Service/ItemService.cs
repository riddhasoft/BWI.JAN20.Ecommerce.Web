using BWI.JAN20.Ecommerce.Model;
using BWI.JAN20.Ecommerce.Data;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWI.JAN20.Ecommerce.Service
{
    internal class ItemService : IItemService
    {
        //todo: add code
        readonly BWIJAN20Context dbContext;
        public ItemService (BWIJAN20Context dbContext)
        {
            this.dbContext = dbContext;
        }
        public int AddItem(ItemModel item)
        {
            throw new NotImplementedException();
        }

        public int DeleteItem(int Id)
        {
            throw new NotImplementedException();
        }

        public ItemModel GetItem(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemModel> GetItems()
        {
            throw new NotImplementedException();
        }

        public bool PublishItem(int itemId, bool hideShow)
        {
            throw new NotImplementedException();
        }

        public bool ShowInHomePage(int itemId, bool hideShow)
        {
            throw new NotImplementedException();
        }

        public int UpdateItem(ItemModel item)
        {
            throw new NotImplementedException();
        }
    }
}
