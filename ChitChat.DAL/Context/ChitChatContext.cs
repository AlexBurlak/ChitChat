using ChitChat.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ChitChat.DAL.Context;

public class ChitChatContext : IdentityDbContext<User, Role, Guid>
{
    public ChitChatContext(DbContextOptions<ChitChatContext> options)
        :base(options)
    {
        
    }
    public DbSet<Chat> Chats { get; set; }
    public DbSet<Message> Messages { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Chat>(eb =>
        {
            eb.HasKey(c => c.Id);
            eb.HasMany(c => c.Participants).WithMany(p => p.Chats);
            eb.Navigation(c => c.Participants).UsePropertyAccessMode(PropertyAccessMode.Property);
            eb.ToTable("Chats");
            
        });
        builder.Entity<User>(eb =>
        {
            eb.ToTable("Users");
        });
        builder.Entity<Role>(eb =>
        {
            eb.ToTable("Roles");
        });
        builder.Entity<Message>(eb =>
        {
            eb.HasKey(m => m.Id);
            eb.Property(m => m.Content).IsRequired().IsUnicode().HasMaxLength(1024);
            eb.Property(m => m.SendTime).IsRequired().HasDefaultValueSql("NOW()");
            eb.HasOne(r => r.Author).WithMany().HasForeignKey(nameof(Message.AuthorId)).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            eb.Navigation(r => r.Author).UsePropertyAccessMode(PropertyAccessMode.Property);
            eb.HasOne(r => r.Reciever).WithMany().HasForeignKey(nameof(Message.RecieverId)).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            eb.Navigation(r => r.Reciever).UsePropertyAccessMode(PropertyAccessMode.Property);
            eb.ToTable("Messages");
        });
        base.OnModelCreating(builder);
    }
}