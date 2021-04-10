using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        private ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        [ValidationAspect(typeof(CardValidator))]
        public IResult Add(Card card)
        {
            _cardDal.Add(card);

            return new SuccessResult(Messages.CardAdded);
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);

            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CardsListed);
        }

        public IDataResult<Card> GetByCardId(int cardId)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.CardId == cardId), Messages.CardListed);
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);

            return new SuccessResult(Messages.CardUpdated);
        }

        public IDataResult<List<CardDetailDto>> GetCardDetails()
        {
            return new SuccessDataResult<List<CardDetailDto>>(_cardDal.GetCardDetails(),Messages.CardsListed);
        }

        public IDataResult<List<CardDetailDto>> GetCardDetailDetailByCardId(int cardId)
        {
            return new SuccessDataResult<List<CardDetailDto>>(_cardDal.GetCarDetailById(cardId,c=>c.CardId==cardId));

        }

        public IDataResult<List<CardDetailDto>> GetCardDetailDetailByUserId(int userId)
        {
            return new SuccessDataResult<List<CardDetailDto>>(
                _cardDal.GetCarDetailByUserId(userId, c => c.UserId == userId));
        }
    }
}
