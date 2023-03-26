namespace Habit_Buddies.Data.Entities
{
    public class UserFriend
    {
        public string UserId { get; set; }
        public virtual User? User { get; set; }
        public int FakeFriendId { get; set; }
        public virtual FakeFriend? FakeFriend { get; set; }

    }
}