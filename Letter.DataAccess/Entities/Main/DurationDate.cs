using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Main
{
    public class DurationDate : EntityBase, IEntity
    {
        public string Date { get; set; }
        public bool IsActive { get; set; }
    }
}