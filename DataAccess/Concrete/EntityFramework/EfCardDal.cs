using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCardDal : EfEntityRepositoryBase<Card, ReCapProjectContext>, ICardDal
    {
        
        public List<CardDetailDto> GetCardDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cd in context.Cards
                    join u in context.Users on cd.UserId equals u.UserId
                    select new CardDetailDto
                    {
                        CardId = cd.CardId,
                        Cvv = cd.Cvv,
                        ExpDate = cd.ExpDate,
                        UserName = u.FirstName,
                        CardNumber = cd.CardNumber
                    };
                return result.ToList();
            }
        }

        public List<CardDetailDto> GetCarDetailById(int cardId, Expression<Func<Card, bool>> filter = null)
        {

            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cd in filter == null ? context.Cards : context.Cards.Where(filter)
                    join u in context.Users on cd.UserId equals u.UserId
                    select new CardDetailDto
                    {
                        CardId = cd.CardId,
                        Cvv = cd.Cvv,
                        ExpDate = cd.ExpDate,
                        UserName = u.FirstName,
                        CardNumber = cd.CardNumber
                    };
                return result.ToList();

            }
        }

        public List<CardDetailDto> GetCarDetailByUserId(int userId, Expression<Func<Card, bool>> filter = null)
        {

            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from cd in filter == null ? context.Cards : context.Cards.Where(filter)
                    join u in context.Users on cd.UserId equals u.UserId
                    select new CardDetailDto
                    {
                        CardId = cd.CardId,
                        Cvv = cd.Cvv,
                        ExpDate = cd.ExpDate,
                        UserName = u.FirstName,
                        CardNumber = cd.CardNumber
                    };
                return result.ToList();

            }
        }
    }
}
