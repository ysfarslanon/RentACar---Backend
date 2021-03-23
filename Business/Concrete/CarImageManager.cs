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

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
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

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(carIm => carIm.Id == id));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

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

        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldpath = Environment.CurrentDirectory + _carImageDal.Get(p => p.Id == carImage.Id).ImagePath;
            carImage.ImagePath = FileHelper.Update(oldpath, file);
            carImage.ImageDate = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }
        private IResult CheckIfImageLimit(int carId)
        {
            var carImagecount = _carImageDal.GetAll(carIm => carIm.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.CarImageLimit);
            }

            return new SuccessResult();
        }
        

        public IResult Delete(CarImage carImage)
        {
            var deletePathOfImage = Environment.CurrentDirectory + _carImageDal.Get(carIm => carIm.Id == carImage.Id).ImagePath;
            FileHelper.Delete(deletePathOfImage);
            _carImageDal.Delete(carImage);
            return new SuccessResult();

        }
       
    }
}
