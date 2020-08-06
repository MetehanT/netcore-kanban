using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.WEBUI.Models
{
	public class BoardCreateAndListModel
	{
		public BoardCreateModel boardCreateModel { get; set; }

		public UserBoardsListModel userBoardsListModel { get; set; }
	}
}
