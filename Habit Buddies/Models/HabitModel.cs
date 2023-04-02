using Habit_Buddies.Data.Entities;

namespace Habit_Buddies.Models
{
    public class HabitModel
    {
        public int HabitId { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }
        
        public string Description { get; set; }

        public string Goal { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public bool IsCompleted { get; set; }
        public bool AllDay { get; set; }

       
    }
     
}
