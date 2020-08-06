using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IEntityRepository<T>
	{
		void Create(T entity);

		List<T> GetAll();

		T GetById(int id);

		void Update(T entity);

		void Delete(T entity);

	}
}
