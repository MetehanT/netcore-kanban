using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BoardManager : IBoardService
	{
		private IBoardDal _boardDal;

		public BoardManager(IBoardDal boardDal)
		{
			_boardDal = boardDal;
		}

		public List<BoardRequest> BoardRequests(int userId)
		{
			return _boardDal.GetBoardRequest(userId);
		}

		public List<User> BoardUserList(int boardId)
		{
			return _boardDal.BoardUserList(boardId);
		}

		public void Create(Board entity)
		{
			_boardDal.Create(entity);
		}

		public void CreateRequest(int uId, int boardId)
		{
			_boardDal.CreateRequest(uId, boardId);
		}

		public void DeletedActive(int id)
		{
			_boardDal.DeletedActive(id);
		}

		public void DeleteUserBoard(int userId, int boardId)
		{
			_boardDal.DeleteUserBoard(userId, boardId);
		}

		public Board GetById(int id)
		{
			return _boardDal.GetById(id);
		}

		public Board GetDetailById(int id, int userId)
		{
			return _boardDal.GetDetailById(id, userId);
		}

		public List<Board> ListByUserId(int userid)
		{
			return _boardDal.ListByUserId(userid);
		}

		public void RequestAccept(BoardRequest entity)
		{
			_boardDal.RequestAccept(entity);
		}

		public void RequestCancel(int id)
		{
			_boardDal.RequestCancel(id);
		}

		public void Update(Board entity)
		{
			_boardDal.Update(entity);
		}
	}
}
