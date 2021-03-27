using Business.Abstract;
using Business.Constants;
using Core.Utilities.Busines;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Business.BusinessAspects.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Business.ValidationRules.FluentValidation;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimit(carImage.CarId)
                );
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();

        }
        [CacheAspect]
        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carIm => carIm.Id == id));
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }
        [CacheAspect]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(carIm => carIm.CarId == carId).Count();
            if (result == 0)
            {
                List<CarImage> carImage = new List<CarImage>();
                carImage.Add(new CarImage { CarId = 0, ImagePath =  @"\Images\default.jpg" });
                return new SuccessDataResult<List<CarImage>>(carImage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(carIm => carIm.CarId == carId));
        }

        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("ICarImageService.Get")]
        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldpath = Environment.CurrentDirectory + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(oldpath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        

        [SecuredOperation("admin", Priority = 1)]
        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            var deletePathOfImage = Environment.CurrentDirectory + _carImageDal.Get(carIm => carIm.Id == carImage.Id).ImagePath;
            FileHelper.Delete(deletePathOfImage);
            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }
        //Business Rule(s)
        private IResult CheckIfImageLimit(int carId)
        {
            var carImagecount = _carImageDal.GetAll(carIm => carIm.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }
            return new SuccessResult();
        }
    }
}
