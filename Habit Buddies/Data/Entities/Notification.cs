namespace Habit_Buddies.Data.Entities
{
    public class Notification
    {
        public Notification()
        {
            
        }

        /*Reminder model: The reminder model represents a reminder that a user has set for a habit. It might include properties like:

ReminderId: A unique identifier for the reminder.

HabitId: The ID of the habit for which the reminder is set.

UserId: The ID of the user who created the reminder.

ReminderTime: The time at which the reminder should be sent.

IsEnabled: A flag indicating whether the reminder is currently enabled.*/

        public int NotificationId { get; set; }

        public string Description { get; set; }
        public string Title { get; set; }
        public int HabitId { get; set; }

        public int UserId { get; set; }

        public DateTime NotificationTime { get; set; }

        public bool IsEnabled { get; set; }




    }
}
