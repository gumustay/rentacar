﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carServices)
        {
            _carDal = carServices;
        }

        public IResult Add(Car car)
        {
            if (car.Name.Count()<=3 || car.DailyPrice<=0)
            {
                return new ErrorResult(Messages.Added);
            }
          
              _carDal.Add(car);
              return new SuccessResult(); 
            
        }



        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(); 
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());  
        }

        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p=> p.Id==id));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult();

        }
    }
}
