using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.WEBUI.Controllers
{
	public class CardsController : Controller
	{
		private ICardService _cardService;

		public CardsController(ICardService cardService)
		{
			_cardService = cardService;
		}

		[HttpPost]
		public void UpdateCards(int[] cardsId, int[] columnsId, int[] positions)
		{
			_cardService.UpdateCardsList(cardsId, columnsId, positions);
		}

		[HttpPost]
		public void Create(string name, int colId)
		{
			var card = new Card {
				Name = name,
				ColumnId = colId,
				Index = 999
			};

			_cardService.Create(card);
		}

		[HttpPost]
		public void ChangeName(string name, int id)
		{
			Card entity = _cardService.GetCardById(id);

			entity.Name = name;

			_cardService.ChangeName(entity);
		}

		[HttpPost]
		public void IsDeletedCard(int cId)
		{
			_cardService.IsDeletedCard(cId);
		}

		public JsonResult CardsDescription(int id)
		{

			var des = _cardService.CardsDescription(id);

			if(des == null || des == "")
			{
				return Json("");
			}
			else
			{
				return Json(des);
			}
		}

		[HttpPost]
		public void UpdateDescription(int cardId, string description)
		{
			_cardService.UpdateDescription(cardId, description);
		}
	}
}
