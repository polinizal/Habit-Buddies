using Microsoft.AspNetCore.Identity;

namespace Habit_Buddies.Data.Entities
{
    public class FriendshipList
    {
        public FriendshipList() {
            Friends = new HashSet<Friend>();
        }
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual ICollection<Friend> Friends { get; set; }

    }
}
