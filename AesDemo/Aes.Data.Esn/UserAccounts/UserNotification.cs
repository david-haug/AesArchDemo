using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Data.Esn.UserAccounts
{
    public class UserAccountNotification
    {
        public int UserAccountNotificationId { get; set; }
        public int UserId { get; set; }
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public int ExpirationDays { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }

    }
}
