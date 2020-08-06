using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
	public interface ICardDal : IEntityRepository<Card>
	{
		List<Card> ListByBoardId(int id);

		void UpdateCardsList(int[] cardsId, int[] columnsId, int[] positions);

		void IsDeletedCard(int cardId);

		string CardsDescription(int id);

		void UpdateDescription(int cardId, string description);

	}
}
