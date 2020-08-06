using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfColumnDal : EfCoreGenericRepository<Column, ApplicationDbContext>, IColumnDal
	{
		public void ColumnDelete(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				var column = context.Columns.FirstOrDefault(c => c.Id == id);

				column.IsDeleted = true;

				context.SaveChanges();
			}
		}

		public List<Column> ListByBoardId(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Columns.Where(c => (c.BoardId == id) && (c.IsDeleted == false))
										.OrderBy(c => c.Index)
										.ToList();
			}
		}

		public void UpdateColumnsList(int[] ids, int[] columns)
		{
			using (var context = new ApplicationDbContext())
			{
				for (int i = 0; i < ids.Length; i++)
				{
					var column = GetById(ids[i]);
					column.Index = (short)columns[i];
					Update(column);
				}
			}
		}
	}
}
