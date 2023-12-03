using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main
{
    public class GetPlaceDto
    {
        public int Id { get; set; }
        public string AzTitle { get; set; }
        public string EnTitle { get; set; }
        public string RuTitle { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public DateTime RegDate { get; set; }
        public bool IsActive { get; set; }
        public GetCityIdNameDto City { get; set; }
        public List<GetPlaceFileDto> PlaceFiles { get; set; }
    }
}
