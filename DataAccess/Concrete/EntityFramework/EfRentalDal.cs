using Core.DataAccess.EntitiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentacarContext> , IRentalDal
    {
        public Rental GetLastValue(Rental rental)
        {
            using (RentacarContext context= new RentacarContext())
            {
                return context.Rentals.OrderBy(p => p.Id).LastOrDefault(p => p.CarId == rental.CarId);
            }
        }

        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentacarContext context= new RentacarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.Id
                             join r in context.Rentals
                             on c.Id equals r.CarId
                             join color in context.Colors
                             on c.ColorId equals color.Id
                             join cust in context.Customers
                             on r.CustomerId equals cust.Id
                             join user in context.Users
                             on cust.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 BrandId = b.Id,
                                 CardId = c.Id,
                                 ColorId = color.Id,
                                 ColorNmae = color.ColorName,
                                 BrandName = b.BrandName,
                                 ModelName = c.Name,
                                 UserName = user.FirstName + " " + user.LastName,
                                 RentDate = r.RentDate,
                                 RetunDate = r.ReturnDate


                             };
                return result.ToList();

            }
        }

        public bool isReturn(Rental rental)
        {
            using (RentacarContext context= new RentacarContext())
            {
                var result = context.Rentals.OrderBy(p => p.Id).LastOrDefault(p=>p.CarId == rental.CarId);  
                if (result.ReturnDate==null)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
