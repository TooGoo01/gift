using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main.Front
{
    public class BodySide : EntityBase, IEntity
    {
        public int ContentId { get; set; }
        public Content Content { get; set; }

        public int AboutBlogId { get; set; }
        public AboutBlog AboutBlog { get; set; }

        public int AboutCountryId { get; set; }
        public AboutCountry AboutCountry { get; set; }

        public int AboutQuestionId { get; set; }
        public AboutQuestion AboutQuestion { get; set; }
    }
}
