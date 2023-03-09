using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;



namespace SocialNetwork.Tests
{
    [TestFixture]
    public class FriendServiceTests
    {
        [Test]
        public void AddFriendReturnException()
        {
            var friendService = new FriendService();

            var friendAddData = new FriendData()
            {
                user_id = 10,
                friend_email = "12gmail"
            };

            Assert.Throws<ArgumentNullException>(() => friendService.AddFriend(friendAddData));

            friendAddData.friend_email = "";

            Assert.Throws<ArgumentNullException>(() => friendService.AddFriend(friendAddData));
        }
    }
}