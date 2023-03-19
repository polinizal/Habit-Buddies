using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;

namespace Habit_Buddies.Data.Entities
{
    public class Habit
    {

        /*
         Habit model: The habit model represents a habit that a user is trying to form or maintain. It might include properties like:

HabitId: A unique identifier for the habit.

UserId: The ID of the user who created the habit.

Title: The title of the habit.

Description: A description of the habit.

Goal: The user's goal for the habit (e.g. "Exercise for 30 minutes every day").

Frequency: The frequency at which the habit should be performed (e.g. "Daily" or "Weekly"). => maham go tva

StartDate: The date on which the user started the habit.

ReminderTime: The time at which the user should be reminded to perform the habit.

IsCompleted: A flag indicating whether the user has completed the habit for the current day/week.*/
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

        public bool IsCompleted { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

    }
}
