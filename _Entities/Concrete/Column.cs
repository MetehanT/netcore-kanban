using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Column : IEntity
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public short Index { get; set; }

		public int BoardId { get; set; }

		public bool IsDeleted { get; set; }

		public Board Board { get; set; }

		public List<Card> Cards	{ get; set; }
	}
}
