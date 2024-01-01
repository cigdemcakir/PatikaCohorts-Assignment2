using TransactionManagementAPI.Entity;
using TransactionManagementAPI.Services.Interfaces;

namespace TransactionManagementAPI.Services.Concretes;

// A fake implementation of IUserService for demonstration.
// In a real application, this would interact with a database or an external service.
public class FakeUserService : IUserService
{
    // A sample list of users for simulation. In a real application, this data would come from a database.
    private List<User> _users = new List<User>
    {
        new User { Id = 1, Username = "user1", Password = "pass1"},
        new User { Id = 2, Username = "user2", Password = "pass2"}
    };

    // Validates a user by checking if the provided username and password match any user in the sample list.
    // In a real-world scenario, this method would authenticate against a database or external service.
    public bool ValidateUser(string username, string password)
    {
        return _users.Any(u => u.Username == username && u.Password == password);
    }

    // Retrieves all users from the sample list.
    // In a real application, this would likely involve querying a database.
    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    // Retrieves a single user by their ID from the sample list.
    // In a production environment, this would involve a database query to fetch the user data.
    public User GetUserById(int id)
    {
        return _users.FirstOrDefault(u => u.Id == id);
    }
}