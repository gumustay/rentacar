using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemory : ICarDal
    {
        List<Car> _cars;
        public InMemory()
        {
            _cars = new List<Car> {
            new Car { Id = 1, ColorId = 2, BrandId = 3, DailyPrice = 25000, Description = "Camaro Cherolet", ModelYear = "2008" },
            new Car { Id = 2, ColorId = 3, BrandId = 4, DailyPrice = 12500, Description = "Mazda" , ModelYear = "2001"},
            new Car { Id = 3, ColorId = 2, BrandId = 5,DailyPrice = 32000,Description = "BMW i8",ModelYear = "2009"}
            };
        }
        public void Add(Car car)
        {
           _cars.Add(car);
            Console.WriteLine("Kayıt Eklendi");
        }

        public void Delete(Car car)
        {
            Car carToDelete = null;
            foreach (var c in _cars)
            {
                if (c.Id == car.Id)
                {
                    carToDelete = c;
                }
            }
            _cars.Remove(carToDelete);

        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            List<Car> list = new List<Car>();
            foreach (var c in _cars)
            {
                if (c.Id == Id)
                {
                    list.Add(c);
                }
            }

            return list;
        }

        public void Update(Car car)
        {
            Car carTuUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carTuUpdate.Id = car.Id;
            carTuUpdate.BrandId = car.BrandId;
            carTuUpdate.DailyPrice = car.DailyPrice;
            carTuUpdate.Description = car.Description;
            carTuUpdate.ModelYear = car.ModelYear;
        }

        public void Try(int id1)
        {
            Console.WriteLine(id1);
        }
    }
}
