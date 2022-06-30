using Microsoft.AspNetCore.Identity;

namespace ChitChat.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
