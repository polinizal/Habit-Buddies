using Microsoft.AspNetCore.Identity;

namespace Habit_Buddies.Data.Entities
{
    public class User: IdentityUser
    {
        public User()
        {
            Habits = new HashSet<Habit>();
        }
        public int Experience { get; set; }
        public string Rank { get; set; } = "procrastinator";
        public virtual ICollection<Habit> Habits { get; set; }

        public virtual ICollection<UserFriendship> FriendsOf { get; set; }
        public virtual ICollection<UserFriendship> Friends { get; set; }
    }
}
