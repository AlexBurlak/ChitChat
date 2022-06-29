namespace ChitChat.Core.Entities
{
    public class Chat
    {
        public Guid Id { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<User> Participants { get; set; }
    }
}
