using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class ColumnManager : IColumnService
	{
		private IColumnDal _columnDal;

		public ColumnManager(IColumnDal columnDal)
		{
			_columnDal = columnDal;
		}

		public void ColumnDelete(int id)
		{
			_columnDal.ColumnDelete(id);
		}

		public void Create(Column entity)
		{
			_columnDal.Create(entity);
		}

		public Column GetById(int id)
		{
			return _columnDal.GetById(id);
		}

		public List<Column> ListByBoardId(int id)
		{
			return _columnDal.ListByBoardId(id);
		}

		public void Update(Column entity)
		{
			_columnDal.Update(entity);
		}

		public void UpdateColumnsList(int[] ids, int[] columns)
		{
			_columnDal.UpdateColumnsList(ids, columns);
		}
	}
}
