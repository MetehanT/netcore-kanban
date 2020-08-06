using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.WEBUI.Models
{
	public class BoardRequestListModel
	{

		public int RequestId { get; set; }

		public int BoardId { get; set; }

		public string BoardName { get; set; }

	}
}
