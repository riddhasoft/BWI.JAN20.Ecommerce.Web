using EcommerceDotnet.Data;
using EcommerceDotnet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDotnet.Web.Controllers
{
	public class ItemController : Controller
	{
		private readonly EcommerceContext _context;

		public ItemController(EcommerceContext context)
		{
			_context = context;
		}

		// GET: ItemModel
		public async Task<IActionResult> Index()
		{
			return _context.Items != null ?
						View(await _context.Items.ToListAsync()) :
						Problem("Entity set 'EcommerceContext.Items'  is null.");
		}

		// GET: Item/Details
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var itemModel = await _context.Items
				.FirstOrDefaultAsync(m => m.Id == id);
			if (itemModel == null)
			{
				return NotFound();
			}

			return View(itemModel);
		}
		[Authorize(Roles = "admin")]
		// GET: Item/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Item/Create

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Price,Discount,DiscountPct")] ItemModel itemModel)
		{
			if (ModelState.IsValid)
			{
				_context.Add(itemModel);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(itemModel);
		}
		[Authorize(Roles = "admin")]
		// GET: Item/Edit
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var ItemModel = await _context.Items.FindAsync(id);
			if (ItemModel == null)
			{
				return NotFound();
			}
			return View(ItemModel);
		}

		// POST: Item/Edit
		
		[HttpPost]
		[ValidateAntiForgeryToken]
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
					_context.Update(itemModel);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StudentModelExists(itemModel.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(itemModel);
		}
		[Authorize(Roles = "admin")]
		// GET: Item/Delete
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Items == null)
			{
				return NotFound();
			}

			var studentModel = await _context.Items
				.FirstOrDefaultAsync(m => m.Id == id);
			if (studentModel == null)
			{
				return NotFound();
			}

			return View(studentModel);
		}

		// POST: Item/Delete
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Items == null)
			{
				return Problem("Entity set 'BWIJAN20WEBContext.StudentModel'  is null.");
			}
			var studentModel = await _context.Items.FindAsync(id);
			if (studentModel != null)
			{
				_context.Items.Remove(studentModel);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StudentModelExists(int id)
		{
			return (_context.Items?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
