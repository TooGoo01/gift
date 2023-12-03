using Letter.DataAccess.Abstractions;
using Letter.DataAccess.Entities.Base;

namespace Letter.DataAccess.Entities.Chat
{
    public class Message : EntityBase, IEntity
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ThreadId { get; set; }
        public bool IsRead { get; set; }


        public MessageThread MessageThread { get; set; }
    }
}
