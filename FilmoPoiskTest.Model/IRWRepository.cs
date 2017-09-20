﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmoPoiskTest.Model
{
	public interface IRWRepository<T, Key> : IRepository<T, Key> where T : class, IKeyable<Key>, new()
	{
		#region Sync
		void Create(T t);

		void Delete(T t);

		void Update(T t);

		T GetItemById(Key Id);
		#endregion

		#region Async
		Task CreateAsync(T t);

		Task DeleteAsync(T t);

		Task UpdateAsync(T t);

		Task<T> GetItemByIdAsync(Key Id);
		#endregion
	}
}
