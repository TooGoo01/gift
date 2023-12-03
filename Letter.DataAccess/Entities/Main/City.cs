using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;
using Letter.DataAccess.Entities.Main;

namespace Letter.Business.Dtos.Get.Main
{
    public class City : EntityBase, IEntity
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public bool IsActive { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }

        public int? HomeCount { get; set; }
        public int? Population { get; set; }
        public ICollection<CityFile> CityFiles { get; set; }
        public ICollection<Home> Homes { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Icon> Icons { get; set; }
    }
}
