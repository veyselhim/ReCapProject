using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        private readonly ICarImageDal _carImageDal;
        private readonly ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal,ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
           IResult result = BusinessRules.Run(CheckNumberOfImage(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            var addedCarImage = CreatedFile(carImage).Data;
            _carImageDal.Add(carImage);

            return new SuccessResult();
        }
        
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);

            return new SuccessResult(Messages.CarImageDeleted);
        }
        
        public IDataResult<List<CarImage>> GetAll()
        {
            

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImageListed);
        }

        public IDataResult<List<CarImage>> GetById(int id)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.Id == id));
        }

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);

            return new SuccessResult(Messages.CarImageUpdated);

        }

        private IDataResult<CarImage> CreatedFile(CarImage carImage)
        {
            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string source = Path.Combine(carImage.ImagePath);

            string result = $"{path}\\{creatingUniqueFilename}";

            try
            {

                File.Move(source, path + "\\" + creatingUniqueFilename);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<CarImage>(exception.Message);
            }

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now }, Messages.CarImageAdded);
        }

        private object UpdatedFile(CarImage carImage)
        {
            var creatingUniqueFilename = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + "_" + DateTime.Now.Year + ".jpeg";

            string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string result = $"{path}\\{creatingUniqueFilename}";

            File.Copy(carImage.ImagePath, path + "\\" + creatingUniqueFilename);

            File.Delete(carImage.ImagePath);

            return new SuccessDataResult<CarImage>(new CarImage { Id = carImage.Id, CarId = carImage.CarId, ImagePath = result, Date = DateTime.Now });
        }

        private IResult CheckNumberOfImage(int carId)
        {
            var result = _carImageDal.GetAll(i => i.CarId == carId).Count;
            if (result>4)
            {
                return new ErrorResult(Messages.NumberOfPicturesCannotBeGreaterThan);
            }

            return new SuccessResult();
        }

    }

  
}
