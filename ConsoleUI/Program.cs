using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Presentation();
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            brandManager.Delete(brandManager.GetById(4).Data);
            if (carManager.GetCarDetails().Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + " / " + car.BrandName + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(carManager.GetCarDetails().Message);
            }

            Presentation();
            Console.ReadKey();
        }

        
        private static void Presentation()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("---------------------YSFARSLANON-----RENT A CAR------------------");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine(DateTime.Now);
        }       
        public static void BrandAdd(BrandManager brandManager,Brand brand)
        {
            brandManager.Add(brand);
        }
    }
}

//Car car1 = new Car()
//{
//    BrandId = 5,
//    ColorId = 1,
//    ModelYear = 2020,
//    DailyPrice = 1500,
//    Description = "Deneme kayit"
//};
//carManager.Update(new Car
//{
//    Id = 20,
//    BrandId = 3,
//    ColorId = 1,
//    DailyPrice = 555,
//    Description = "554",
//    ModelYear = 19988
//});
//Console'da Tüm CRUD operasyonlarınızı Car, Brand, Model nesneleriniz için test ediniz. 
//GetAll, GetById, Insert, Update, Delete.

