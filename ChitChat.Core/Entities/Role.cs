using Microsoft.AspNetCore.Identity;

namespace ChitChat.Core.Entities;

public class Role : IdentityRole<Guid>, IBaseEntity
{
    
}