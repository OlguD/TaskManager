using TaskManagerBackend.Data;
using TaskManagerBackend.Models;
using TaskManagerBackend.Exceptions;
using TaskManagerBackend.Utils;
using TaskManagerBackend.Helpers;
namespace TaskManagerBackend.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;
    private readonly JwtHelper _jwtHelper;

    public UserRepository(AppDbContext context, JwtHelper jwtHelper)
    {
        _context = context;
        _jwtHelper = jwtHelper;
    }
    
    public async Task<User> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            return user;
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException("User with the given ID does not exist.", ex);
        }
    }
    
    public async Task<User> GetUserByUsernameAsync(string username)
    {
        try
        {
            var user = await _context.Users.FindAsync(username);
            if (user == null) throw new UserNotFoundException();
            return user;
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException("User with the given username does not exist.", ex);
        }
    }
    
    public async Task<string?> Validate(string username, string passwordHash)
    {
        try
        {
            var user = await GetUserByUsernameAsync(username);
            if (user.Username == username && PasswordHash.VerifyPassword(passwordHash, user.PasswordHash))
            {
                var token = _jwtHelper.GenerateToken(user.Username);
                return token;
            }
        }
        catch (UserNotFoundException ex)
        {
            throw new UserNotFoundException("User with the given username does not exist.", ex);
        }
        catch (ValidationException ex)
        {
            throw new ValidationException("Username or Password incorrect", ex);
        }

        return null;
    }

    public async Task AddUserAsync(User user)
    {   
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}