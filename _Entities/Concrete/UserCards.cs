using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class UserCards
	{
		public int UserId { get; set; }

		public User User { get; set; }

		public int CardId { get; set; }

		public Card Card { get; set; }
	}
}
