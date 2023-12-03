using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main
{
    public class UpdatePlaceViewModel
    {
        public IEnumerable<GetCityDto>? Cities { get; set; }
        public GetPlaceDto Place { get; set; }
    }
}
