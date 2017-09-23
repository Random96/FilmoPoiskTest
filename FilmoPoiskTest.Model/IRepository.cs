using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Model
{
	public interface IRepository<T> where T : class, IKeyable, new()
	{
		IEnumerable<T> GetList(int From, int PageSize);

		IEnumerable<T> GetListBack(int From, int PageSize);

		Task<IEnumerable<T>> GetListAsync(int From, int PageSize);

		Task<IEnumerable<T>> GetListBackAsync(int From, int PageSize);

	}
}
