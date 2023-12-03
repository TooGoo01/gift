using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Chat
{
    public class MessageThread : EntityBase, IEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsRead { get; set; }

        public ICollection<ThreadMember> ThreadMembers { get; set; }
    }
}
