using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;
using Letter.DataAccess.Entities.Main;

namespace Letter.Business.Dtos.Get.Main
{
    public class Home : EntityBase, IEntity
    {
        public string? AzName { get; set; }
        public string? EnName { get; set; }
        public string? RuName { get; set; }

        public string? AzDescription { get; set; }
        public string? EnDescription { get; set; }
        public string? RuDescription { get; set; }

        public int CityId { get; set; }
        public string? MapAdrress { get; set; }
        public string? AzAddress { get; set; }
        public string? EnAddress { get; set; }
        public string? RuAddress { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public double Price { get; set; }
       
        public bool IsActive { get; set; }
        public City? City { get; set; }
        public int TypeId { get; set; }
        public int TimeTypeId { get; set; } 
        public int StatusId { get; set; }
       
        public ICollection<HomeFile>? HomeFiles { get; set; }
        public HomeType? Type { get; set; }
        public TimeType? TimeType{ get; set; }
        public Status Status { get; set; }
    }
}
