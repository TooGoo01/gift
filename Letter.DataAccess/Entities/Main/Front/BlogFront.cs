using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;


namespace Letter.DataAccess.Entities.Main.Front
{
    public class BlogFront : EntityBase, IEntity
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }

        public string AzDescription { get; set; }
        public string EnDescription { get; set; }
        public string RuDescription { get; set; }
    }
}
