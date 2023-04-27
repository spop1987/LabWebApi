using System;
using LabDotNet.Models.Dtos;
using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;

namespace LabDotNet.Common.Tests
{
    public static class CommonTestFactory
    {
        private static Random random = new Random();
        private static string _userType = "Admin";
        public static Register CreateRegister(string email,
                                              string password,
                                              string userType,
                                              string firstName,
                                              string lastName)
        {
            return new Register
            {
                Email = email,
                Password = password,
                UserType = userType,
                FirstName = firstName,
                LastName = lastName
            };
        }

        public static User CreateUser(int randomLength, string hashedPassword, UserDto? userDto = null)
        {
            if(userDto != null)
                return new User
                {
                    FirstName = userDto.FirstName,
                    LastName = userDto.LastName,
                    Email = userDto.Email,
                    Password = hashedPassword,
                    UserType = userDto.UserType,
                    CreateDate = userDto.CreateDate,
                    UpdateDate = userDto.UpdateDate
                };
            
            var randomString = RandomString(randomLength);
            return new User
            {
                FirstName = $"SomeFirstNAme{randomString}",
                LastName = $"SomeLastNAme{randomString}",
                Email = $"SomeEmail{randomString}",
                Password = hashedPassword,
                UserType = _userType,
                CreateDate = DateTime.UtcNow.AddYears(-30),
                UpdateDate = DateTime.UtcNow.AddYears(-30)
            };
        }

        public static string CreateHash(int length)
        {
            return RandomString(length);
        }

        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        } 
    }
}