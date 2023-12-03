using Letter.DataAccess.Entities.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Letter.Business.Dtos.Get.Main
{
    public class GetUniversityForDirection
    {
        public int Id { get; set; }

        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string MapAdrress { get; set; }
        public string AzAddress { get; set; }
        public string EnAddress { get; set; }
        public string RuAddress { get; set; }
        public string AzCity { get; set; }
        public string EnCity { get; set; }
        public string RuCity { get; set; }
        public ICollection<GetHomeFileDto> UniversityFiles { get; set; }
        public GetCityIdNameDto Country { get; set; }
    }
}
