using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class CardManager : ICardService
	{
		private ICardDal _cardDal;

		public CardManager(ICardDal cardDal)
		{
			_cardDal = cardDal;
		}

		public string CardsDescription(int id)
		{
			return _cardDal.CardsDescription(id);
		}

		public void ChangeName(Card entity)
		{
			_cardDal.Update(entity);
		}

		public void Create(Card entity)
		{
			_cardDal.Create(entity);
		}

		public Card GetCardById(int id)
		{
			return _cardDal.GetById(id);
		}

		public void IsDeletedCard(int cardId)
		{
			_cardDal.IsDeletedCard(cardId);
		}

		public List<Card> ListByBoardId(int id)
		{
			return _cardDal.ListByBoardId(id);
		}

		public void UpdateCardsList(int[] cardsId, int[] columnsId, int[] positions)
		{
			_cardDal.UpdateCardsList(cardsId, columnsId, positions);
		}

		public void UpdateDescription(int cardId, string description)
		{
			_cardDal.UpdateDescription(cardId, description);
		}
	}
}
