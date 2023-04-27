using LabDotNet.Models.Entities;

namespace LabDotNet.DataBase.DataAccess.Interfaces
{
    public interface ICommands
    {
        long AddUser(User user);
    }
}