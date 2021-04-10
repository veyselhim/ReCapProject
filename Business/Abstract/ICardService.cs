using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> GetByCardId(int cardId);
        IResult Add(Card card);
        IResult Delete(Card card);
        IResult Update(Card card);

        IDataResult<List<CardDetailDto>> GetCardDetails();

        IDataResult<List<CardDetailDto>> GetCardDetailDetailByCardId(int cardId);
        IDataResult<List<CardDetailDto>> GetCardDetailDetailByUserId(int userId);



    }
}
