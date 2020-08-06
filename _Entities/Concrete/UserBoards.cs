using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class UserBoards
	{
		public int BoardId { get; set; }

		public Board Board { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }

		public int RoleId { get; set; }
	}
}
