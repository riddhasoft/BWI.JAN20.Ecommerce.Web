﻿using EcommerceDotnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDotnet.Data
{
	public class EcommerceContext:DbContext
	{
		public EcommerceContext(DbContextOptions<EcommerceContext> options)
	   : base(options)
		{
		}

		public DbSet<ItemModel> Items { get; set; }
		public DbSet<CheckOutModel> CheckoutItems { get; set; }
		public DbSet<UserModel> Users { get; set; }
	}
}
