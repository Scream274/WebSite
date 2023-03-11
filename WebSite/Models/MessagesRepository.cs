using WebSite.Entities;

namespace WebSite.Models
{
    public class MessagesRepository
    {
        private static List<GuestMessage> __guestMessages = new List<GuestMessage>();

        public static void AddGuestMessage(GuestMessage message)
        {
            __guestMessages.Add(message);
        }
    }
}
