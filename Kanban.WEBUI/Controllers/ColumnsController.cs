using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.WEBUI.Controllers
{
	public class ColumnsController : Controller
	{
		private IColumnService _columnService;

		public ColumnsController(IColumnService columnService)
		{
			_columnService = columnService;
		}

		[HttpPost]
		public void UpdateColumn(int[] ids, int[] positions)
		{
			if((ids != null && positions != null) && (ids.Length == positions.Length))
				_columnService.UpdateColumnsList(ids, positions);

		}

		[HttpPost]
		public void Create(string name, short columnCount, int boardId)
		{

			var column = new Column
			{
				Name = name,
				BoardId = boardId,
				Index = (short)(columnCount + 1)
			};

			if (name != null)
				_columnService.Create(column);

		}

		[HttpPost]
		public void Delete(int id)
		{

			_columnService.ColumnDelete(id);

		}

		[HttpPost]
		public void ChangeName(string name, int id)
		{
			Column entity = _columnService.GetById(id);

			entity.Name = name;

			_columnService.Update(entity);
		}
	}
}
