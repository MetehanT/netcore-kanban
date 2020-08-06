using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCardDal : EfCoreGenericRepository<Card, ApplicationDbContext>, ICardDal
	{
		public string CardsDescription(int id)
		{
			using (var context = new ApplicationDbContext())
			{
				var card = context.Cards.FirstOrDefault(c => c.Id == id);

				return card.Description;
			}
		}

		public void IsDeletedCard(int cardId)
		{
			using (var context = new ApplicationDbContext())
			{
				Card card = context.Cards.FirstOrDefault(c => c.Id == cardId);

				card.IsDeleted = true;

				context.SaveChanges();

			}
		}

		public List<Card> ListByBoardId(int id)
		{
			using(var context = new ApplicationDbContext())
			{
				return context.Cards.Include(i => i.Column)
									.Where(i => i.Column.BoardId == id)
									.Where(i => i.IsDeleted == false)
									.OrderBy(i => i.Index)
									.ToList();
			}
		}

		public void UpdateCardsList(int[] cardsId, int[] columnsId, int[] positions)
		{
			using (var context = new ApplicationDbContext())
			{
				for (int i = 0; i < cardsId.Length; i++)
				{
					var card = GetById(cardsId[i]);

					card.Index = (short)positions[i];
					card.ColumnId = columnsId[i];
					Update(card);

				}
			}
		}

		public void UpdateDescription(int cardId, string description)
		{
			using (var context = new ApplicationDbContext())
			{
				var card = context.Cards.FirstOrDefault(c => c.Id == cardId);

				card.Description = description;

				context.SaveChanges();
			}
		}
	}
}
