using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(Contact contact);

        IResult Update(Contact contact);

        IResult Delete(Contact contact);

        IDataResult<List<Contact>> GetAll();

        IDataResult<Contact> GetById(int contactId);
    }
}
