using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);

        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.CustomerId == customerId));
        }

        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new Result(true, Messages.CustomerDeleted);
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new Result(true, Messages.CustomerUpdated);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {

            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails(),Messages.CustomerListed);
        }

        public IDataResult<CustomerDetailDto> GetByEmail(string email)
        {
            return new SuccessDataResult<CustomerDetailDto>(_customerDal.GetByEmail(c => c.Email == email),Messages.CustomerListed);
        }
    }
}
