using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Business.Abstract
{
	public interface ICardService
	{
		void Create(Card entity);

		List<Card> ListByBoardId(int id);

		void UpdateCardsList(int[] cardsId, int[] columnsId, int[] positions);

		Card GetCardById(int id);

		void ChangeName(Card entity);

		void IsDeletedCard(int cardId);

		string CardsDescription(int id);

		void UpdateDescription(int cardId, string description);
	}
}
