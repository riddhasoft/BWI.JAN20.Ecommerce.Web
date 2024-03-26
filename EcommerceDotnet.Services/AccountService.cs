using EcommerceDotnet.Data;
using EcommerceDotnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDotnet.Services
{
    public class AccountService : IAccountService
    {
        private EcommerceContext _context;
        public AccountService(EcommerceContext context)
        {
            _context = context;
        }
        public async Task<int> Add(UserModel user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<int> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
            return -1;//user may be null here
        }

        public async Task<UserModel> Find(int id)
        {
            return await _context.Users.FindAsync(id);
        }


        public async Task<List<UserModel>> List()
        {
            return await _context.Users.ToListAsync();
        }


        public async Task<int> Update(UserModel user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
    }
}
