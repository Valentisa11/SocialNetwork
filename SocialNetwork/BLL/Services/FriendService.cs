using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.DAL.Entities;
using SocialNetwork.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.BLL.Services
{
    /// <summary>
    /// Сервис для работы с профилями друзей (добавление)
    /// </summary>
    public class FriendService
    {
        IUserRepository userRepository;
        IFriendRepository friendRepository;

        public FriendService()
        {
            userRepository = new UserRepository();
            friendRepository = new FriendRepository();
        }

        /// <summary>
        /// Добавление пользователя в друзья
        /// </summary>
        /// <param name="friendAddData">Введ данных пользователя, для добавления</param>
        public void AddFriend(FriendData friendAddData)
        {
            if (String.IsNullOrEmpty(friendAddData.friend_email))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendAddData.friend_email))
                throw new ArgumentNullException();

            var findFrendEntity = this.userRepository.FindByEmail(friendAddData.friend_email);
            if (findFrendEntity is null)
                throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendAddData.user_id,
                friend_id = findFrendEntity.id
            };

            if (friendEntity.user_id == friendEntity.friend_id)
                throw new UserNotFoundException();

            if (this.friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}