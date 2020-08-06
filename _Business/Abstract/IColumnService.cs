using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IColumnService
	{
		List<Column> ListByBoardId(int id);

		void Create(Column entity);

		void UpdateColumnsList(int[] ids, int[] columns);

		void ColumnDelete(int id);

		Column GetById(int id);

		void Update(Column entity);
	}
}
