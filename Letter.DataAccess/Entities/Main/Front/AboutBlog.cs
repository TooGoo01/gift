using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class AboutBlog : EntityBase, IEntity
    {
        public string AzHeader { get; set; }
        public string EnHeader { get; set; }
        public string RuHeader { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
