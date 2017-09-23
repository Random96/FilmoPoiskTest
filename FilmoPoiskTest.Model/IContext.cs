using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Model
{
	/// <summary>
	/// 
	/// </summary>
    public interface IContext
	{
		DbSet<T> Set<T>() where T : class;

		Task<int> SaveChangesAsync();

		int SaveChanges();
	}
}
