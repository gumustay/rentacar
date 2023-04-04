using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class RentalDetailDto : IDto
    {
        public int RentalId { get; set; }
        public int CardId { get; set; }  
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int CustomerId { get; set; }
        public string BrandName { get; set; }
        public string ColorNmae { get; set; }
        public string ModelName { get; set; }
        public string UserName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? RetunDate { get; set; }
    }
}
