using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IColumnDal : IEntityRepository<Column>
	{
		List<Column> ListByBoardId(int id);

		void UpdateColumnsList(int[] ids, int[] columns);

		void ColumnDelete(int id);
	}
}
