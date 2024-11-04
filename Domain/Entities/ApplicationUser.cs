using Microsoft.AspNetCore.Identity;
namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public long? TelegramChatId { get; set; }
        public ICollection<NotificationChannel> NotificationChannels { get; set; } = [];
    }
}
