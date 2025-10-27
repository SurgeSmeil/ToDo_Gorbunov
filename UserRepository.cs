using System;
using BCrypt.Net;
using System.Collections.Generic;

namespace RegistrationApp
{
    public class UserRepository
    {
        private static List<User> _users = new List<User>(); // В реальном коде замените базой данных

        public static bool RegisterUser(string login, string password, string name)
        {
            if (IsLoginTaken(login))
            {
                return false;
            }

            string hashedPassword = PasswordHasher.HashPassword(password);
            _users.Add(new User { Login = login, Password = hashedPassword, Name = name });
            return true;
        }

        public static bool AuthenticateUser(string login, string password)
        {
            foreach (var user in _users)
            {
                if (user.Login == login && PasswordHasher.VerifyPassword(password, user.Password))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsLoginTaken(string login)
        {
            foreach (var user in _users)
            {
                if (user.Login == login)
                {
                    return true;
                }
            }
            return false;
        }

        // Метод для получения информации о пользователе по логину
        public static User GetUserByLogin(string login)
        {
            foreach (var user in _users)
            {
                if (user.Login == login)
                {
                    return user;
                }
            }
            return null; // Или выбросить исключение
        }

        // Метод для обновления информации о пользователе (пример)
        public static bool UpdateUserName(string login, string newName)
        {
            User user = GetUserByLogin(login);
            if (user != null)
            {
                user.Name = newName;
                // В реальном приложении нужно обновить запись в базе данных
                return true;
            }
            return false;
        }

        public static class PasswordHasher
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password, BCrypt.Net.BCrypt.GenerateSalt());
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
            }
        }
    }
}

