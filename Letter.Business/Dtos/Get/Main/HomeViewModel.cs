using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main
{
    public class HomeViewModel
    {
        public IEnumerable<GetCityDto>? Cities { get; set; }
        public IEnumerable<GetHomeTypeDto>? Types { get; set; }
        public IEnumerable<GetTimeTypeDto>? TimeTypes { get; set; }
        public IEnumerable<GetHomeDto>? Homes { get; set; }
        public IEnumerable<GetHomeDto>? Hotel { get; set; }
       

    }
}
