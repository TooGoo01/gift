using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class File : EntityBase, IEntity
    {
        public string FileName { get; set; }
        public string Path { get; set; }
    }
}
