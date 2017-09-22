using FilmoPoiskTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace FilmoPoiskTest.Data
{
	public class CinemaService : ICinemaService
	{

		private Model.IRWRepository<Cinema> m_Rep;

		public CinemaService(Model.IRWRepository<Cinema> rep)
		{
			m_Rep = rep;
		}


		public Task CreateAsync(string User, CinemaViewModels src)
		{
			throw new NotImplementedException();
		}

		public Task DeleteAsync(string User, int Id)
		{
			throw new NotImplementedException();
		}

		public Task EditAsync(string User, CinemaViewModels src)
		{
			throw new NotImplementedException();
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
