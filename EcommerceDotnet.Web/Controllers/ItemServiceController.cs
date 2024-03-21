using EcommerceDotnet.Models;
using EcommerceDotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDotnet.Web.Controllers
{
	public class ItemServiceController : Controller
	{
		readonly IItemService _itemService;

		public ItemServiceController(IItemService itemService)
		{
			_itemService = itemService;
		}
		public IActionResult Index()
		{
			return View();
		}
		// GET: Item/AddItem
		public IActionResult Create()
		{
			return View();
		}
		//POST: Item/Create
		[HttpPost, ActionName("Create")]
		public async Task<IActionResult> AddItem([Bind("Id,Name,Price,Discount,DiscountPct")] ItemModel itemModel)
		{

			if (ModelState.IsValid)
			{
				_itemService.AddItem(itemModel);
				 return RedirectToAction(nameof(Index));
			}
			return View(itemModel);
		}
		// GET: Item/Delete
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var bookModel = _itemService.GetItem(id ?? 0);
			if (bookModel == null)
			{
				return NotFound();
			}

			return View(bookModel);
		}

		// POST: Item/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{

			_itemService.DeleteItem(id);
			return RedirectToAction(nameof(Index));
		}

		public IActionResult Update()
		{
			return View();
		}
		[HttpPost, ActionName("Update")]
		public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Discount,DiscountPct")] ItemModel itemModel)
		{
			if (id != itemModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_itemService.UpdateItem(itemModel);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error occurred while updating item {ex.Message}");
				}
				return RedirectToAction(nameof(Index));
			}
			return View(itemModel);
		}
		// GET: Shop/GetItem
		public async Task<IActionResult> Details(int? id)
		{
			var book = _itemService.GetItem(id ?? 0);

			return View(book);
		}
	}
}
