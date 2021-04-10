using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IImagesService
    {
        IResult Add(IFormFile file, Images carImage);
        IResult Delete(Images carImage);
        IResult Update(IFormFile file, Images carImage);
        IDataResult<Images> Get(int id);
        IDataResult<List<Images>> GetAll();
        IDataResult<List<Images>> GetImagesByCarId(int id);
    }
}
