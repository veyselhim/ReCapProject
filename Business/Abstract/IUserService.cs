using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();

        List<OperationClaim> GetClaims(User user);

        IResult EditProfil(User user, string password);

        IDataResult<User> GetById(int userId);

        User GetByEmail(string email);

        IDataResult<User> GetUserByEmail(string email);


        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);

    }
}
