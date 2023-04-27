using LabDotNet.DataBase.DataAccess.Interfaces;
using LabDotNet.Models.Entities;

namespace LabDotNet.DataBase.DataAccess
{
    public class Queries : IQueries
    {
        private readonly LabDbContext _context;

        public Queries(LabDbContext context)
        {
            _context = context;
        }
        public User? FindUserByEmail(string email)
        {
            return _context.Users.Where(u => u.Email == email).FirstOrDefault();
        }
    }
}