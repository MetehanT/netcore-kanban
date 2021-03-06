﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
	public class BoardRequest
	{
		public int Id { get; set; }

		public int BoardId { get; set; }

		public Board Board { get; set; }

		public int UserId { get; set; }

		public User User { get; set; }
	}
}
