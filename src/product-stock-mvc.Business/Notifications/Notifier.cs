using product_stock_mvc.Business.Interfaces;

namespace product_stock_mvc.Business.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> notifications;

        public Notifier()
        {
            notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return notifications;
        }

        public bool HasNotification()
        {
            return notifications.Any();
        }
    }
}
