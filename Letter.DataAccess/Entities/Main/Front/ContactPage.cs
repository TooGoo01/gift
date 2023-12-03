using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class ContactPage : EntityBase, IEntity
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzBody { get; set; }
        public string EnBody { get; set; }
        public string RuBody { get; set; }

        public string Map { get; set; }
        public ICollection<ContactPageFile> ContactPageFiles { get; set; }
    }
}
