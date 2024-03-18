using Microsoft.AspNetCore.Mvc;
using EcommerceDotnet.Data;
using EcommerceDotnet.Services;
using EcommerceDotnet.Models;
using Microsoft.EntityFrameworkCore;
namespace EcommerceDotnet.Web.Controllers
{
	public class ShopController : Controller
	{
		readonly EcommerceContext _context;
		public ShopController(EcommerceContext context)
		{
			_context = context;
		}
		// GET: Shop/AddItem
		public IActionResult Create()
		{
			return View();
		}
		//POST: Shop/AddItem
		[HttpPost,ActionName("Create")]
		public async Task<IActionResult> AddItem([Bind("Id,Name,Price,Discount")] ItemService service)
		{
			if (ModelState.IsValid)
			{
				_context.Add(service);
				await _context.SaveChangesAsync();
			}
			return View(service);
		}
		// GET: Shop/Delete
		public async Task<IActionResult> DeleteItem(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var itemModel =await _context.Items.FirstOrDefaultAsync(m => m.Id == id);
			if (itemModel == null)
			{
				return NotFound();
			}

			return View(itemModel);
		}

		// POST: Shop/Delete
		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Items == null)
			{
				return Problem("Entity set 'EcommerceContext.Items'  is null.");
			}
			var itemModel = await _context.Items.FindAsync(id);
			if (itemModel != null)
			{
				_context.Items.Remove(itemModel);
			}

			await _context.SaveChangesAsync();
			return View(itemModel);
		}

		public IActionResult Update()
		{
			 return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(int id, [Bind("Id,Name,Price,Discount")] ItemModel itemModel)
		{
			if (id != itemModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(itemModel);
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error occurred while updating item {ex.Message}");
				}
			}
			return View(itemModel);
		}
		// GET: Shop/GetItem
		public async Task<IActionResult> GetItem(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var userModel = await _context.Items
				.FirstOrDefaultAsync(m => m.Id == id);
			if (userModel == null)
			{
				return NotFound();
			}

			return View(userModel);
		}
	}
}
