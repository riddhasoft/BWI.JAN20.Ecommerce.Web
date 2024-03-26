﻿using EcommerceDotnet.Models;
using Newtonsoft.Json;

namespace EcommerceDotnet.Web.Common
{
    public class MySession
    {
        IHttpContextAccessor _httpContextAccessor;

        public MySession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<ItemModel> CartItems
        {
            get
            {
                var cartItems = new List<ItemModel>();
                var itemInSession = _httpContextAccessor.HttpContext?.Session.GetString("CartItems");
                if (itemInSession != null)
                {
                    cartItems = JsonConvert.DeserializeObject<List<ItemModel>>(itemInSession)?? new List<ItemModel>(); ;

                }

                return cartItems;
            }

            set
            {

                _httpContextAccessor?.HttpContext?.Session.SetString("CartItems", Serialize(value));

            }
        }
        private string Serialize(object? value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
