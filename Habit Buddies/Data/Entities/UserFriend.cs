namespace Habit_Buddies.Data.Entities
{
    public class UserFriend
    {
        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public int FriendId { get; set; }
        public virtual Friend? Friend { get; set; }

    }
}