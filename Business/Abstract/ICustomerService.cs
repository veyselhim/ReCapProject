using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();

        // IDataResult<List<Users>> GetUsersById(int id);


        //  IDataResult<List<CarDetailDto>> GetCarDetails();

        IDataResult<Customer> GetById(int customerId);

        IResult Add(Customer customer);

        IResult Delete(Customer customer);

        IResult Update(Customer customer);
    }
}
