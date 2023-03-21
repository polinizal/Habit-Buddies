namespace Habit_Buddies.Data.Entities
{
    public class Friend
    {
        public int FriendId { get; set; }
        public virtual ICollection<UserFriend> UserFriends { get; set; }
    }
}
