using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class BlogCategory : EntityBase, IEntity
    {
        public string Name { get; set; } = string.Empty!;
        public ICollection<Blog> Blogs { get; set; }
        public bool IsActive { get; set; }
    }
}
