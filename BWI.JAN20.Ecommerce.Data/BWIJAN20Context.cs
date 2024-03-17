using BWI.JAN20.Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BWI.JAN20.Ecommerce.Data
{
    public class BWIJAN20Context :DbContext
    {
        public BWIJAN20Context(DbContextOptions<BWIJAN20Context> options) : base(options)
        {

        }
        DbSet<ItemModel> Items { get; set; }

    }
}
