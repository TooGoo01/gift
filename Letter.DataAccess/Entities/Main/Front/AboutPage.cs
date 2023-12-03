using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class AboutPage : EntityBase, IEntity
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }
        public string AzBody { get; set; }
        public string EnBody { get; set; }
        public string RuBody { get; set; }
        public ICollection<AboutPageFile> AboutPageFiles { get; set; }
    }
}
