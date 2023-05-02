using LabDotNet.Models.Dtos;
using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;
using Xunit;

namespace LabDotNet.Common.Tests
{
    public static class EntityAsserts
    {
        public static async Task AssertUserDtoAsync(UserDto userExpected, UserDto userLogin)
        {
            var tasks = new List<Task>();
            tasks.AddRange(new List<Task>
            {
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.FirstName, userLogin.FirstName);
                }),
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.LastName, userLogin.LastName);
                }),
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.Email, userLogin.Email);
                }),
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.UserType, userLogin.UserType);
                })
            });
            Task t = Task.WhenAll(tasks);
            await t;
        }

        public static async Task AssertUserAsync(User userExpected, Register register)
        {
            var tasks = new List<Task>();
            tasks.AddRange(new List<Task>
            {
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.FirstName, register.FirstName);
                }),
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.LastName, register.LastName);
                }),
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.Email, register.Email);
                }),
                Task.Run(() => 
                {
                    Assert.Equal(userExpected.UserType, register.UserType);
                })
            });
            Task t = Task.WhenAll(tasks);
            await t;
        }
    }
}