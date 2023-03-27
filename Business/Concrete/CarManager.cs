using Business.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarService _car;

        public CarManager(ICarService carServices)
        {
            _car = carServices;
        }
        public List<Car> GetAll()
        {
            return _car.GetAll();
        }
    }
}
