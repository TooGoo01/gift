using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;
using Letter.DataAccess.Entities.Main;

namespace Letter.Business.Dtos.Get.Main
{
    public class Speciality : EntityBase, IEntity
    {
        public string AzName { get; set; }
        public string EnName { get; set; }
        public string RuName { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Direction> Directions { get; set; }
        //public ICollection<Duration> Durations { get; set; }
        //public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Home> Universities { get; set; }
    }
}
