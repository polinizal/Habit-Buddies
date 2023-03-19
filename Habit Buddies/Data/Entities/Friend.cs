namespace Habit_Buddies.Data.Entities
{
    public class Friend
    {
        public int FriendshipListId { get; set; }
        public virtual FriendshipList? FriendshipList { get; set; }

        public int FriendUserId { get; set; }
        public virtual User? FriendUser { get; set; }
    }
}