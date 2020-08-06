using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	public class User : IdentityUser<int>
	{
		public List<UserBoards> userBoards { get; set; }

		public List<UserCards> UserCards { get; set; }

		public List<BoardRequest> BoardRequests { get; set; }
	}
}
