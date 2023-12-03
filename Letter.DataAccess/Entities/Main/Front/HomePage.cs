using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class HomePage : EntityBase, IEntity
    {
        public int HeaderSideId { get; set; }
        //public HeaderSide HeaderSide { get; set; }

        public int BodySideId { get; set; }
        public BodySide BodySide { get; set; }

        public int FooterSideId { get; set; }
        public FooterSide FooterSide { get; set; }
    }
}
