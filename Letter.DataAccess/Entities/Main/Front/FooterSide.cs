using Letter.Business.Dtos.Get.Main;
using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class FooterSide : EntityBase, IEntity
    {
        public ICollection<HomeType> Types { get; set; }
        public ICollection<City> Countries { get; set; }
    }
}
