using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main
{
    public class CityViewModel
    {
        public IEnumerable<GetPlaceDto>? Places { get; set; }
        public GetCityDto City { get; set; }
    }
}
