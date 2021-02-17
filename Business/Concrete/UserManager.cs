using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

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

        public IResult Add(User user)
        {
            if (user.FirstName.Length<2)
            {
                return new ErrorResult(Messages.UserInvalid);
            }
            _userDal.Add(user);

            return new Result(true, Messages.UserAdded);
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
    }
}
