using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Habit_Buddies.Data.Entities
{
    public class Habit
    {

        public Habit()
        {
            Notifications = new HashSet<Notification>();
        }
        public int HabitId { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }
        public virtual User? User { get; set; }
        public string Description { get; set; }

        public string Goal { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public double PercentageCompleted { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCompletedToday { get; set; }
        public int CompletedDays { get; set; }
        public DateTime LastCompletedDate { get; set; }
        public bool AllDay { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

    }
}
