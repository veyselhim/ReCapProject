using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using FluentValidation;

namespace Business.Concrete
{
    public class UserManager:IUserService
    {

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        IUserDal _userDal;
        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.UserListed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.UserId == userId));
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            _userDal.Add(user);

            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new Result(true, Messages.UserDeleted);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);

            return new Result(true, Messages.UserUpdated);


        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);

        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
