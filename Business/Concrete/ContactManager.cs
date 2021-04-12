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

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {

        private IContactDal _contactDal ;

         public ContactManager(IContactDal contactDal)
         {
             _contactDal = contactDal;
         }

         [ValidationAspect(typeof(ContactValidator))]
         public IResult Add(Contact contact)
        {
            _contactDal.Add(contact);
            
            return new SuccessResult(Messages.contactAdded);
        }

        public IResult Delete(Contact contact)
        {
            _contactDal.Delete(contact);

            return new SuccessResult();
        }

        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(),Messages.contacsListed);
        }

        public IDataResult<Contact> GetById(int contactId)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(c => c.ContactId == contactId));
        }

        public IResult Update(Contact contact)
        {
            _contactDal.Update(contact);

            return new SuccessResult();
        }
    }
}
