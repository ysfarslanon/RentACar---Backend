using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=500,ModelYear=1996,Description="Opel 1996 Astra Beyaz"},
                new Car{CarId=2,BrandId=1,ColorId=2,DailyPrice=800,ModelYear=2017,Description="Opel 2017 Astra Siyah"},
                new Car{CarId=3,BrandId=2,ColorId=1,DailyPrice=1500,ModelYear=2012,Description="Volvo 2012 S60 Beyaz"},
                new Car{CarId=4,BrandId=2,ColorId=2,DailyPrice=5000,ModelYear=2020,Description="Volvo 2020 S90 Siyah"},
                new Car{CarId=5,BrandId=3,ColorId=3,DailyPrice=5000,ModelYear=2007,Description="Mercedes 2007 Vito Gri"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description= car.Description;

        }
    }
}
