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



       // IDataResult<List<Users>> GetUsersById(int id);


      //  IDataResult<List<CarDetailDto>> GetCarDetails();
       
        IDataResult<User> GetById(int userId);

        User GetByEmail(string email);

        IResult Add(User user);

        IResult Delete(User user);

        IResult Update(User user);

    }
}
