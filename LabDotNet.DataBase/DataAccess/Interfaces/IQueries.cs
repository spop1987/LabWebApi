using LabDotNet.Models.Entities;

namespace LabDotNet.DataBase.DataAccess.Interfaces
{
    public interface IQueries
    {
        User FindUserByEmail(string email);
    }
}