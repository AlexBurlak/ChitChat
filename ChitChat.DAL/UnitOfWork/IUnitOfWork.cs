namespace ChitChat.DAL;

public interface IUnitOfWork
{
    public IChatRepository ChatRepository { get; set; }
    public Task<int> SaveAsync();
}