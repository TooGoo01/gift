using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class Page : EntityBase, IEntity
    {
        public About About { get; set; }
        public Blog Blog { get; set; }
        public Contact Contact { get; set; }
    }
}
