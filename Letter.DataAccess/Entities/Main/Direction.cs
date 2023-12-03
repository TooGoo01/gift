using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class Direction : EntityBase, IEntity
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }
        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public ICollection<DirectionFile> DirectionFiles { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Speciality> Specialities { get; set; }
        public ICollection<Home> Universities { get; set; }
    }
}
