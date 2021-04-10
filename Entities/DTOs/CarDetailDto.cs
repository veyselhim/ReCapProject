using System.Collections.Generic;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarDetailDto:IDto
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public int UnitPrice { get; set; }
        public List<string> Images { get; set; }
        public int CarFindexScore { get; set; }


    }
}
