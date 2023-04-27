using LabDotNet.DataBase.DataAccess.Interfaces;
using LabDotNet.Models.Entities;

namespace LabDotNet.DataBase.DataAccess
{
    public class Commands : ICommands
    {
        private readonly LabDbContext _context;

        public Commands(LabDbContext context)
        {
            _context = context;
        }
        public long AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }
    }
}