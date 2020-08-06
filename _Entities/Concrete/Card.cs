using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Card : IEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public short Index { get; set; }

		public int ColumnId { get; set; }

		public bool IsDeleted { get; set; }

		public Column Column { get; set; }

		public List<UserCards> UserCards { get; set; }
	}
}
