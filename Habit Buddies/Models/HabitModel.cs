using Habit_Buddies.Data.Entities;

namespace Habit_Buddies.Models
{
    public class HabitModel
    {
        public int HabitId { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }
        public virtual User? User { get; set; }
        public string Description { get; set; }

        public string Goal { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsCompleted { get; set; }
        public bool AllDay { get; set; }

       
    }
     
}
