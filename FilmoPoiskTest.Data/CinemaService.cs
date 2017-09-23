using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FilmoPoiskTest.Model;

namespace FilmoPoiskTest.Data
{
	public class CinemaService : ICinemaService
	{

		private Model.IRWRepository<Cinema> m_Rep;

		public CinemaService(Model.IRWRepository<Cinema> rep)
		{
			m_Rep = rep;
		}

		public async Task CreateAsync(string User, CinemaViewModelsWithPoster src)
		{
			src.User = User;

			await m_Rep.CreateAsync(Mapper.Map<Cinema>(src));
		}

		public Task DeleteAsync(string User, int Id)
		{
			throw new NotImplementedException();
		}

		public async Task EditAsync(string User, CinemaViewModelsWithPoster src)
		{
			await m_Rep.UpdateAsync(Mapper.Map<Cinema>(src));
		}

		public async Task<CinemaViewModelsWithPoster> GetById(int Id)
		{
			var ret = await m_Rep.GetItemByIdAsync(Id);

			return Mapper.Map<CinemaViewModelsWithPoster>(ret);
		}

		public async Task<IEnumerable<CinemaViewModels>> GetListAsync(int Pos, int Direct, int Count)
		{
			IEnumerable<Cinema> ret;
			switch (Direct)
			{
				case 1:
					ret = await m_Rep.GetListAsync(Pos, Count);
					break;

				case -1:
					ret = await m_Rep.GetListBackAsync(Pos, Count);
					break;
				default:
					return new List<CinemaViewModels>();
			}

			var mapped = ret.Select(x => Mapper.Map<CinemaViewModels>(x));

			return mapped;
		}
	}
}
