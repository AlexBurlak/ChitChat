namespace ChitChat.Core.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public Guid RecieverId { get; set; }
        public User Reciever { get; set; }
        public Guid ChatId { get; set; }
        public Chat Chat { get; set; }
        public DateTime SendTime { get; set; }
    }
}
