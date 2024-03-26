using EcommerceDotnet.Models;
using EcommerceDotnet.Services;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceDotnet.Web.Controllers
{
    public class AccountController : Controller
    {
        readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        /*================================================================*/
        public async  Task<IActionResult> Index()
        {
            List<UserModel> items =await _accountService.List();
            return View(items);
        }
        /*================================================================*/
        [HttpGet,ActionName("AddUser")]
        public IActionResult Create()
        {
            return View();
        }
        [ActionName("AddUser")]
        public async Task<IActionResult> Add(UserModel user)
        {
            if(ModelState.IsValid)
            {
                await _accountService.Add(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
        /*================================================================*/
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = _accountService.Find(id ?? 0);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _accountService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        /*================================================================*/
        [HttpGet,ActionName("Edit")]
     
        public async Task<IActionResult> Update(int id)
        {
            var user = await _accountService.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user); 
        }
        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> Update(int id, UserModel user) 
        {
            if(ModelState.IsValid)
            {
                await _accountService.Update(user);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
