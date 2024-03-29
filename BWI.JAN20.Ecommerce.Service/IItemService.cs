﻿using BWI.JAN20.Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWI.JAN20.Ecommerce.Service
{
    public interface IItemService
    {
        List<ItemModel> GetItems();
        ItemModel GetItem(int id);
        int UpdateItem(ItemModel item);
        int DeleteItem(int Id);
        int AddItem(ItemModel item);

        bool PublishItem(int itemId,bool hideShow);
        bool ShowInHomePage(int itemId,bool hideShow);
    }
}
