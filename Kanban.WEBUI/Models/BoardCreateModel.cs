using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.WEBUI.Models
{
	public class BoardCreateModel
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }
	}
}
