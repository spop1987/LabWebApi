using LabDotNet.Models.Entities;
using LabDotNet.Models.Request;
using Xunit;

namespace LabDotNet.Common.Tests
{
    public static class EntityAsserts
    {
        public async static Task AssertUserAsync(User userExpected, Register register)
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