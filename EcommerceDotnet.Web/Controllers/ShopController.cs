using Microsoft.AspNetCore.Mvc;
using EcommerceDotnet.Data;
using EcommerceDotnet.Services;
using EcommerceDotnet.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using EcommerceDotnet.Web.Common;
namespace EcommerceDotnet.Web.Controllers
{

    public class ShopController : Controller
    {
        MySession _session;

        readonly IShopService _shopService;

        public ShopController(IShopService shopService, MySession session)
        {
            _shopService = shopService;
            _session = session;
        }
        //
        public IActionResult Index()
        {
            List<ItemModel> items = _shopService.ListItemsInShop();
            return View(items);
        }


        public async Task<IActionResult> ListItemsInShop(int? id)
        {
            var item = _shopService.ListItemInShop(id ?? 0);

            return View(item);
        }

        //Get
        [ActionName("Cart")]
        public IActionResult Create()
        {
            return View();
        }
        //POST: Shop/AddToCart
        [HttpPost, ActionName("Cart")]
        public IActionResult AddToCart(int itemId)
        {


            var item = _shopService.GetItem(itemId);
            var items = _session.CartItems;
            items.Add(item);
            _session.CartItems = items;


            return View(_session.CartItems); // Redirect to Cart
        }
        [ActionName("Delete")]

        public async Task<IActionResult> RemoveFromCart(int? itemId)
        {
            var item= _session.CartItems.Find(x => x.Id == itemId);
            var items = _session.CartItems;
            items.Remove(item);
            _session.CartItems = items;
            return View("Cart",items);
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            _shopService.RemoveFromCart(id);
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Checkout(List<CheckOutModel> itemId)
        {
            if (ModelState.IsValid)
            {
                _shopService.Checkout(itemId);
                return RedirectToAction(nameof(Index));
            }
            return View(itemId);
        }
        public string Serialize(object? value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}
