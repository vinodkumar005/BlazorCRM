using Radzen;

namespace Blazor.Web.Services
{
    public class CustomNotificationService
    {
        private readonly NotificationService _notificationService;

        // Inject NotificationService through constructor
        public CustomNotificationService(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        // Centralized function to display notifications
        public void ShowNotification(NotificationSeverity severity, string message)
        {
            _notificationService.Notify(new NotificationMessage
            {
                Severity = severity,
                Detail = message,
                Duration = 5000
            });
        }
    }
}
