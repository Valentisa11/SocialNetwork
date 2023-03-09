using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;

namespace SocialNetwork.PLL.Views
{
    /// <summary>
    /// Интерфейс добавления пользователя в друзья
    /// </summary>
    public class FriendAddView
    {
        FriendService friendService = new FriendService();

        /// <summary>
        /// Отображение интерфейса 
        /// </summary>
        /// <param name="user">текущий пользователь</param>
        public void Show(User user)
        {
            FriendData friendAddData = new FriendData();

            Console.Write("\nВведите email пользователя для добавления в друзья:");
            friendAddData.friend_email = Console.ReadLine();

            friendAddData.user_id = user.Id;

            try
            {
                friendService.AddFriend(friendAddData);
                SuccessMessage.Show("Пользователь успешно добавлен в друзья.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
            }

            catch (ArgumentNullException)
            {
                AlertMessage.Show("Введите корректное значение!");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении друга!");
            }
        }
    }
}