using Business.Abstract;
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
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            this._rentalDal = rentalDal;

        }
        //public IResult Add(Rental entity)
        //{
        //    _rentalDal.Add(entity);
        //    return new SuccessResult();
        //}

        public IResult Add(Rental entity)
        {
            //foreach (var item in _rentalDal.GetAll(p=> p.CarId==entity.CarId))
            //{
            //    if (item.ReturnDate==DateTime.MinValue)
            //    {
            //        Console.WriteLine( " ");
            //        return new ErrorResult("Arama Müşteride");
            //    }
            //}

            var result = _rentalDal.GetAll(c => c.CarId == entity.CarId).OrderBy(x => x.Id).LastOrDefault();

            if (result.ReturnDate == null)
            {
                return new ErrorResult(Messages.NotAdded );
            }

            _rentalDal.Add(entity);
            return new SuccessResult();
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult();
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult();
        }
        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }


        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail());
        }
    }
}
