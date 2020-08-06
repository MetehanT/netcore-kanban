using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface IBoardService
	{
		List<Board> ListByUserId(int userid);

		Board GetById(int id);

		void Create(Board entity);

		Board GetDetailById(int id, int userId);

		List<BoardRequest> BoardRequests(int userId);

		void CreateRequest(int uId, int boardId);

		void RequestAccept(BoardRequest entity);

		void RequestCancel(int id);

		void Update(Board entity);

		List<User> BoardUserList(int boardId);

		void DeleteUserBoard(int userId, int boardId);

		void DeletedActive(int id);
	}
}
