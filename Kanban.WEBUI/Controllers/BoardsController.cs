using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Kanban.WEBUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json;

namespace Kanban.WEBUI.Controllers
{
	[Authorize]
	public class BoardsController : Controller
	{
		private IBoardService _boardService;
		private IColumnService _columnService;
		private ICardService _cardService;
		private UserManager<User> _userManager;

		public BoardsController(IBoardService boardService, UserManager<User> userManager, IColumnService columnService, ICardService cardService)
		{
			_boardService = boardService;
			_userManager = userManager;
			_columnService = columnService;
			_cardService = cardService;
		}

		public IActionResult Index()
		{
			var userId = _userManager.GetUserId(User);

			List<Board> boards = _boardService.ListByUserId(Convert.ToInt32(userId));

			var model = new BoardCreateAndListModel { userBoardsListModel = new UserBoardsListModel { Boards = boards } };

			return View(model);
		}

		[HttpPost]
		public IActionResult Index(BoardCreateAndListModel model)
		{
			var userId = _userManager.GetUserId(User);

			if (!ModelState.IsValid)
			{
				List<Board> boards = _boardService.ListByUserId(Convert.ToInt32(userId));

				return View(new BoardCreateAndListModel { userBoardsListModel = new UserBoardsListModel { Boards = boards } });
			}

			var entity = new Board()
			{
				Name = model.boardCreateModel.Name
			};

			entity.userBoards = new List<UserBoards>();

			entity.userBoards.Add(new UserBoards()
			{
				UserId = Convert.ToInt32(userId),
				RoleId = 1,
				Board = entity
			});

			_boardService.Create(entity);

			return Redirect("/boards");
		}


		public IActionResult Detail(int id)
		{
			var userId = _userManager.GetUserId(User);
			Board board = _boardService.GetDetailById(id, Convert.ToInt32(userId));

			UserBoards ub = board.userBoards.Where(ub => ub.BoardId == board.Id)
											.FirstOrDefault(ub => ub.UserId == Convert.ToInt32(userId));


			if (board != null)
			{
				ViewBag.id = board.Id;
				ViewBag.userRoleId = ub.RoleId;
				ViewBag.boardId = board.Id;
				return View();
			}
			else
			{
				return NotFound();
			}

		}

		public IActionResult BoardRequest()
		{
			var userId = _userManager.GetUserId(User);

			ViewBag.id = Convert.ToInt32(userId);

			return View();
		}

		public JsonResult BoardDetail(int id)
		{
			Board board = _boardService.GetById(id);

			if (board != null)
			{
				var model = new BoardDetailViewModel
				{
					BoardId = board.Id,
					BoardName = board.Name,
					Columns = _columnService.ListByBoardId(board.Id),
					Cards = _cardService.ListByBoardId(board.Id),
				};


				return Json(model);
			}
			else
			{
				return Json("");
			}
		}

		public JsonResult BoardRequestJson()
		{

			var userId = _userManager.GetUserId(User);

			var brs = _boardService.BoardRequests(Convert.ToInt32(userId));
			
			if (brs != null)
			{
				return Json(brs);
			}
			else
			{
				return Json("");
			}
		}

		[HttpPost]
		public void RequestAccept(int id)
		{
			BoardRequest br = new BoardRequest
			{
				Id = id
			};
			_boardService.RequestAccept(br);

		}

		[HttpPost]
		public void RequestCancel(int id)
		{
			_boardService.RequestCancel(id);
		}


		[HttpPost]
		public void BoardInvitation(int uId, int boardId)
		{
			_boardService.CreateRequest(uId, boardId);
		}

		[HttpPost]
		public void BoardNameChange(string name, int id)
		{
			Board entity =  _boardService.GetById(id);

			entity.Name = name;

			_boardService.Update(entity);
		}

		[HttpPost]
		public void DeleteUserBoard(int userId, int boardId)
		{
			_boardService.DeleteUserBoard(userId, boardId);
		}

		[HttpPost]
		public void BoardDelete(int id)
		{
			_boardService.DeletedActive(id);

		}

		public JsonResult BoardUserList(int boardId)
		{

			var board = _boardService.BoardUserList(boardId);

			if (board != null)
			{
				return Json(board);
			}
			else
			{
				return Json("");
			}
		}

		
	}
}