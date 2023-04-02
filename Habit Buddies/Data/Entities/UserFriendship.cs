namespace Habit_Buddies.Data.Entities
{
    public class UserFriendship
    {
        public string UserId { get; set; }
        public virtual User? User { get; set; }

        public string UserFriendId { get; set; }
        public virtual User? UserFriend { get; set; }
    }
}
