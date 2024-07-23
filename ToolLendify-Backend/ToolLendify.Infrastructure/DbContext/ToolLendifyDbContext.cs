using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolLendify.Domain.Entities;

namespace ToolLendify.Infrastructure.DbContext
{
	public class ToolLendifyDbContext:IdentityDbContext<User>
	{
		public ToolLendifyDbContext(DbContextOptions<ToolLendifyDbContext>options):base(options)
		{ }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
