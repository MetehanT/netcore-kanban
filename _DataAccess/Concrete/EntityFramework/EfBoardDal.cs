using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfBoardDal : EfCoreGenericRepository<Board, ApplicationDbContext>, IBoardDal
	{

		public List<User> BoardUserList(int boardId)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Users.Include(u => u.userBoards)
												.ThenInclude(ub => ub.Board)
												.Where(u => u.userBoards.Any(ub => (ub.BoardId == boardId) && (ub.RoleId == 3)))
												.ToList();
			}
		}

		public void CreateRequest(int uId, int boardId)
		{
			using (var context = new ApplicationDbContext())
			{
				var result =  context.BoardRequests.Where(br => br.BoardId == boardId)
									.FirstOrDefault(br => br.UserId == uId);

				if(result == null)
				{
					var br = new BoardRequest
					{
						BoardId = boardId,
						UserId = uId
					};

					context.Set<BoardRequest>().Add(br);
					context.SaveChanges();
				}
			}
		}

		public void DeletedActive(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				var board = context.Boards.FirstOrDefault(b => b.Id == id);

				board.IsDeleted = true;

				context.SaveChanges();
			}
		}

		public void DeleteUserBoard(int userId, int boardId)
		{
			using (var context = new ApplicationDbContext())
			{
				UserBoards ub = new UserBoards
				{
					BoardId = boardId,
					UserId = userId,
					RoleId = 3
				};

				context.Set<UserBoards>().Remove(ub);
				context.SaveChanges();


			}
		}

		public List<BoardRequest> GetBoardRequest(int userId)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.BoardRequests.Include(br => br.Board)
											.Where(br => br.UserId == userId)
											.ToList();
			}
		}

		public Board GetDetailById(int id, int userId)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Boards.Where(b => b.Id == id)
										.Include(b => b.userBoards)
										.ThenInclude(b => b.User)
										.Where(i => i.userBoards.Any(a => a.UserId == userId))
										.FirstOrDefault();
			}
		}

		public List<Board> ListByUserId(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				return context.Boards.Include(i => i.userBoards)
										.ThenInclude(i => i.User)
										.Where(b => b.IsDeleted == false)
										.Where(i => i.userBoards.Any(a => a.UserId == id))
										.ToList();
			}
		}

		public void RequestAccept(BoardRequest entity)
		{
			using (var context = new ApplicationDbContext())
			{

				BoardRequest br = context.BoardRequests.Where(br => br.Id == entity.Id).FirstOrDefault();

				if (br != null)
				{
					Board board = context.Boards.Include(i => i.userBoards)
												.FirstOrDefault(b => b.Id == br.BoardId);

					board.userBoards.Add(new UserBoards
					{
						UserId = br.UserId,
						BoardId = br.BoardId,
						RoleId = 3
					});
					context.Set<BoardRequest>().Remove(br);
					context.SaveChanges();
				}
			}
		}

		public void RequestCancel(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				var entity = context.BoardRequests.Where(b => b.Id == id).FirstOrDefault();

				context.Set<BoardRequest>().Remove(entity);
				context.SaveChanges();
			}
		}
	}
}
