using System;
using System.Collections.Generic;
using System.Text;

namespace Aes.Data.Esn.Common
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public int ExpirationDays { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public int ModifiedBy { get; set; }
    }
}
