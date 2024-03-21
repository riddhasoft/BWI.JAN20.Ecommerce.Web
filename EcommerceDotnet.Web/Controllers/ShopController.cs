using Microsoft.AspNetCore.Mvc;
using EcommerceDotnet.Data;
using EcommerceDotnet.Services;
using EcommerceDotnet.Models;
using Microsoft.EntityFrameworkCore;
namespace EcommerceDotnet.Web.Controllers
{
    [Route("Shop/index")]
    public class ShopController : Controller
    {

        readonly IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ListItemsInShop(int? id)
        {
            var item = _shopService.ListItemInShop(id ?? 0);

            return View(item);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }
        //POST: Shop/AddToCart
        [HttpPost, ActionName("AddToCart")]
        public async Task<IActionResult> AddToCart([Bind("Id,Country,FirstName,LastName,CompanyName,Email,Address,Phone,Notes,Amount")] CheckOutModel Model)
        {

            if (ModelState.IsValid)
            {
                _shopService.AddToCart(Model);
                return RedirectToAction(nameof(Index));
            }
            return View(Model);
        }
        // GET: Shop/Remove
        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Model = _shopService.ListItemInShop(id ?? 0);
            if (Model == null)
            {
                return NotFound();
            }

            return View(Model);
        }

        // POST: Shop/Remove
        [HttpPost, ActionName("RemoveFromCart")]
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
    }
}
