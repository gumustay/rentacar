using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        //List<Car> GetAll();
        //List<Car> GetById(int Id);
        //void Add(Car car);
        //void Delete(Car car);
        //void Update(Car car);

        List<CarDetailDto> GetCarDetails();
    }
}
