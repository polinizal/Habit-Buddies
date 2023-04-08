using Microsoft.AspNetCore.Identity;

namespace Habit_Buddies.Data.Entities
{
    public class Notification
    {
        public Notification()
        {
            
        }

        public int NotificationId { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }

        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public DateTime NotificationTime { get; set; }

        public bool IsEnabled { get; set; }
        public int HabitId { get; set; }
        public virtual Habit? Habit { get; set; }

    }
}
