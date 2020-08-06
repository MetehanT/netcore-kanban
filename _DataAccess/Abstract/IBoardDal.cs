using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface IBoardDal : IEntityRepository<Board>
	{
		List<Board> ListByUserId(int id);

		Board GetDetailById(int id, int userId);

		List<BoardRequest> GetBoardRequest(int userId);

		void CreateRequest(int uId, int boardId);

		void RequestAccept(BoardRequest entity);

		void RequestCancel(int id);

		List<User> BoardUserList(int boardId);

		void DeleteUserBoard(int userId, int boardId);

		void DeletedActive(int id);
	}
}
