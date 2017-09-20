using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;



namespace FilmoPoiskTest.Data
{
	public class ApplicationDbContext : IdentityDbContext<Model.ApplicationUser>, Model.IContext
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}

		public DbSet<Data.Cinema> Cinemas { get; set; }
	}	
}
