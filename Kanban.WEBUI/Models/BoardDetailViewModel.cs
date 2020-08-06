using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.WEBUI.Models
{
	public class BoardDetailViewModel
	{
		public int BoardId { get; set; }

		public string BoardName { get; set; }

		public List<Column> Columns { get; set; }

		public List<Card> Cards { get; set; }

		//public ColumnCreateUpdateModel ColumnCreateUpdateModel { get; set; }

		//public CardCreateUpdateModel CardCreateUpdateModel { get; set; }
	}

	public class ColumnCreateUpdateModel
	{
		public int BoardId { get; set; }

		public string Name { get; set; }
	}

	public class CardCreateUpdateModel
	{
		public int ColumnId { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }
	}
}
