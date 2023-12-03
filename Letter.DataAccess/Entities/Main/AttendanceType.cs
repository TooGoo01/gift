using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class AttendanceType : EntityBase, IEntity
    {
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}