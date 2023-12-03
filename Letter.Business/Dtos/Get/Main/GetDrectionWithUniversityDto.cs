using Letter.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main
{
    public class GetDrectionWithUniversityDto
    {
        public int Id { get; set; }
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public ICollection<GetDirectionFileDto> DirectionFiles { get; set; }
        public ICollection<GetUniversityForDirection> Universities { get; set; }
        public ICollection<GetSpecialityIdNameDto> Specialities { get; set; }
    }
}
