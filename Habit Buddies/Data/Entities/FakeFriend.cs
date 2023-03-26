namespace Habit_Buddies.Data.Entities
{
    public class FakeFriend
    {
        public int FakeFriendId { get; set; }
        public string? FriendName { get; set; }
        public string? FriendRank { get; set; }

        public virtual ICollection<UserFriend>? UserFriends { get; set; }
    }
}
