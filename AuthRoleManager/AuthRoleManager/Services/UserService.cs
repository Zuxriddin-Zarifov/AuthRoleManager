using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Infrastructures.Interface;
using AuthRoleManager.Services.Interface;

namespace AuthRoleManager.Services;

public class UserService : IUserService
{
    public IHeshService _heshService;
    private IUserRepository _userRepository;
    public UserService(IUserRepository userRepository,IHeshService heshService)
    {
        _userRepository = userRepository;
        _heshService = heshService;
    }


    public async Task<User> CreateAsync(UserDto userDto)
    {
        if (userDto is null)
            throw new Exception("Invalid input data");
        User user = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password =await _heshService.HeshClientPasswordAsync(userDto.Password)
        };
        var result = await _userRepository.CreatAsync(user);

        return result;
    }

    public async Task<User> GetByEmailPasswordAsync(string email, string password)
    {
        var user = _userRepository.
            DbGetSet().
            FirstOrDefault(user => 
            (user.Email == email && user.Password == password));
        if (user is null)
            throw new Exception("user not found");
        return user;
    }

    public async Task<User> GetByIdAsync(long id)
    {
        var result = await _userRepository.GetByIdAsync(id);

        return result;
    }
}
