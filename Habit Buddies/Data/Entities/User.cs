using Microsoft.AspNetCore.Identity;

namespace Habit_Buddies.Data.Entities
{
    public class User:IdentityUser
    {
        public User()
        {
            Habits = new HashSet<Habit>();
        }
        public virtual FriendshipList FriendshipList { get; set; }
        public virtual ICollection<Habit> Habits { get; set; }

    }
}
