using ChitChat.Core.Entities;
using ChitChat.DAL.Context;

namespace ChitChat.DAL.Repositories;

public class ChatRepository : GenericRepository<Chat>, IChatRepository
{
    public ChatRepository(ChitChatContext context) : base(context)
    {
    }
}