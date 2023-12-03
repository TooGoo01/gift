using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;
using Letter.DataAccess.Entities.Libraries;

namespace Letter.DataAccess.Entities.Chat
{
    public class ThreadMember : EntityBase, IEntity
    {
        public int Id { get; set; }
        public int ThreadId { get; set; }
        public int UserId { get; set; }
        public int ThreadMemberRoleId { get; set; }

        public MessageThread MessageThread { get; set; }
        public ThreadMemberRole ThreadMemberRole { get; set; }
    }
}
