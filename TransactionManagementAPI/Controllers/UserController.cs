using Microsoft.AspNetCore.Mvc;
using TransactionManagementAPI.Entity;
using TransactionManagementAPI.Services.Interfaces;

namespace TransactionManagementAPI.Controllers;

// UserController manages user-related operations.
// It interacts with the IUserService to perform operations like fetching and validating users.
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    // Constructor for UserController, expects a dependency of IUserService.
    // Dependency injection is used here to inject the service.
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // Gets all the users.
    // Route: GET api/user
    // This endpoint retrieves all users from the user service.
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        return Ok(_userService.GetAllUsers());
    }

    // Gets a single user by their ID.
    // Route: GET api/user/{id}
    // This endpoint fetches a user by their unique identifier.
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        return Ok(user);
    }
    
    // Validates a user's credentials.
    // Route: POST api/user/validate
    // This endpoint checks if the user credentials are valid.
    [HttpPost("Validate")]
    public IActionResult ValidateUser(User user)
    {
        if (_userService.ValidateUser(user.Username, user.Password))
        {
            return Ok("User is valid.");
        }
        else
        {
            return BadRequest("Invalid username or password.");
        }
    }
}