using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Models
{
	public interface ICinemaService
	{
		Task<IEnumerable<CinemaViewModels>> GetListAsync(int Pos, int Direct, int Count);

		Task CreateAsync(string User, CinemaViewModels src);
		Task EditAsync(string User, CinemaViewModels src);
		Task DeleteAsync(string User, int Id);
	}
}
