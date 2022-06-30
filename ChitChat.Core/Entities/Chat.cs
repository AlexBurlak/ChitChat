namespace ChitChat.Core.Entities
{
    public class Chat : IBaseEntity
    {
        public ICollection<Message> Messages { get; set; }
        public ICollection<User> Participants { get; set; }
        public Guid Id { get; set; }
    }
}
