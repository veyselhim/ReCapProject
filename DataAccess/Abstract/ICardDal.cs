using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICardDal:IEntityRepository<Card>
    {
        List<CardDetailDto> GetCardDetails();

        List<CardDetailDto> GetCarDetailById(int cardId, Expression<Func<Card, bool>> filter = null);

        List<CardDetailDto> GetCarDetailByUserId(int userId, Expression<Func<Card, bool>> filter = null);


    }
}
