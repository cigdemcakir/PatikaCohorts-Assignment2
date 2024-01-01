using TransactionManagementAPI.Entity;

namespace TransactionManagementAPI.Services.Interfaces;

// Interface defining user authentication-related operations
public interface IUserService
{
    bool ValidateUser(string username, string password);
    
    IEnumerable<User> GetAllUsers();
    
    User GetUserById(int id);
}