using Microsoft.AspNetCore.Identity;

namespace ChitChat.Core.Entities
{
    public class User : IdentityUser<Guid>, IBaseEntity
    {
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
