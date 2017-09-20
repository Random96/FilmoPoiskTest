using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Data
{
	public class Repository<T> : Model.IRWRepository<T, int>, IDisposable where T : class, Model.IKeyable<int>, new()
	{
		private Model.IContext m_Context;

		public Repository(Model.IContext Context)
		{
			m_Context = Context ?? throw new ArgumentNullException(nameof(Context));
		}

		public void Create(T t)
		{
			var table = m_Context.Set<T>();
			table.Add(t);
			m_Context.SaveChanges();
		}

		public async Task CreateAsync(T t)
		{
			var table = m_Context.Set<T>();
			table.Add(t);
			await m_Context.SaveChangesAsync();
		}

		public void Delete(T t)
		{
			var table = m_Context.Set<T>();
			table.Remove(t);
			m_Context.SaveChanges();
		}

		public async Task DeleteAsync(T t)
		{
			var table = m_Context.Set<T>();
			table.Remove(t);
			await m_Context.SaveChangesAsync();
		}

		public T GetItemById(int Id)
		{
			var table = m_Context.Set<T>();
			var ret = table.FirstOrDefault(x => x.Id == Id);
			return ret;
		}

		public async Task<T> GetItemByIdAsync(int Id)
		{
			var table = m_Context.Set<T>();
			var ret = await table.FirstOrDefaultAsync(x => x.Id == Id);
			return ret;
		}

		public IEnumerable<T> GetList(int From, int PageSize)
		{
			var table = m_Context.Set<T>();

			IQueryable<T> ret = table.Where(x => x.Id >= From).OrderBy(x => x.Id);

			if (PageSize > 0)
				ret = ret.Take(PageSize);

			return ret.ToList();
		}

		public async Task<IEnumerable<T>> GetListAsync(int From, int PageSize)
		{
			var table = m_Context.Set<T>();

			IQueryable<T> ret = table.Where(x => x.Id >= From).OrderBy(x => x.Id);

			if (PageSize > 0)
				ret = ret.Take(PageSize);

			return await ret.ToListAsync();
		}

		public IEnumerable<T> GetListBack(int From, int PageSize)
		{
			var table = m_Context.Set<T>();

			IQueryable<T> ret = table.Where(x => x.Id <= From).OrderByDescending(x => x.Id);

			ret = ret.Reverse();

			if (PageSize > 0)
				ret = ret.Take(PageSize);

			return ret.ToList();
		}

		public async Task<IEnumerable<T>> GetListBackAsync(int From, int PageSize)
		{
			var table = m_Context.Set<T>();

			IQueryable<T> ret = table.Where(x => x.Id <= From).OrderByDescending(x => x.Id);

			ret = ret.Reverse();

			if (PageSize > 0)
				ret = ret.Take(PageSize);

			return await ret.ToListAsync();
		}

		public void Update(T t)
		{
			var table = m_Context.Set<T>();

			var dest = table.FirstOrDefault(x => x.Id == t.Id);
			if( dest != null )
			{
				foreach( var prop in typeof(T).GetProperties())
				{
					if( prop.Name != "Id")
						prop.SetValue(dest, prop.GetValue(t));
				}
			}
			m_Context.SaveChanges();
		}

		public async Task UpdateAsync(T t)
		{
			var table = m_Context.Set<T>();

			var dest = await table.FirstOrDefaultAsync(x => x.Id == t.Id);
			if (dest != null)
			{
				foreach (var prop in typeof(T).GetProperties())
				{
					if (prop.Name != "Id")
						prop.SetValue(dest, prop.GetValue(t));
				}
			}
			await m_Context.SaveChangesAsync();
		}

		#region IDisposable Support
		private bool disposedValue = false; 

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				m_Context = null;

				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
		}

		private void CheckDisposed()
		{
			if (disposedValue)
				throw new ObjectDisposedException(nameof(Repository<T>));
		}
		#endregion
	}
}
