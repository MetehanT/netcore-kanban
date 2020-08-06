using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class Board : IEntity
	{
		public int Id { get; set; }
		
		public string Name { get; set; }

		public bool IsDeleted { get; set; }

		public List<Column> Columns { get; set; }

		public List<UserBoards> userBoards { get; set; }

		public List<BoardRequest> BoardRequests { get; set; }
	}
}
