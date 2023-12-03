using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class BlogPage : EntityBase, IEntity
    {
        public string AzBlogHeader { get; set; }
        public string EnBlogHeader { get; set; }
        public string RuBlogHeader { get; set; }

        public string AzBlogBody { get; set; }
        public string EnBlogBody { get; set; }
        public string RuBlogBody { get; set; }

        public ICollection<BlogPageFile> BlogPageFiles { get; set; }
    }
}
