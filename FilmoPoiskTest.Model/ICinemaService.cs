using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Model
{
	public interface ICinemaService
	{
		Task<IEnumerable<CinemaViewModels>> GetListAsync(int Pos, int Direct, int Count);

		Task<CinemaViewModelsWithPoster> GetById(int Id);

		Task CreateAsync(string User, CinemaViewModelsWithPoster src);

		Task EditAsync(string User, CinemaViewModelsWithPoster src);
	}
}
