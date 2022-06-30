using ChitChat.DAL.Context;

namespace ChitChat.DAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly ChitChatContext _context;
    public IChatRepository ChatRepository { get; set; }
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}