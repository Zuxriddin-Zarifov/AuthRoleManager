using AuthRoleManager.Domain.Dtos;
using AuthRoleManager.Domain.Entity;
using AuthRoleManager.Infrastructures.Interface;
using AuthRoleManager.Services.Interface;

namespace AuthRoleManager.Services;

public class UserService : IUserService
{
    public IHeshService _heshService;
    private  IOTPService _oTPService;
    private IUserRepository _userRepository;
    public UserService(IUserRepository userRepository,IHeshService heshService,IOTPService oTPService)
    {
        _userRepository = userRepository;
        _heshService = heshService;
        _oTPService = oTPService;
    }


    public async Task<User> CreateAsync(UserCreateDto userDto)
    {
        if (userDto is null)
            throw new Exception("Invalid input data");
        var otp = await _oTPService.GenerateOTPAsync();
        User user = new User()
        {
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = await _heshService.HeshClientPasswordAsync(userDto.Password),
            OTP = otp,
            OTPLiveDatetime = DateTime.UtcNow.AddMinutes(3)  // 3 minutli otp live 
        };
        var result = await _userRepository.CreatAsync(user);

        return result;
    }

    public async Task<User> DeleteAsync(long id)
    {
        return await _userRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<User>> GetByAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetByEmailPasswordAsync(string email, string password)
    {
        var heshPassword = await _heshService.HeshClientPasswordAsync(password);
        var user = await _userRepository.GetByEmailPassword(email, heshPassword);
        if (user is null)
            throw new Exception("user not found");
        return user;
    }

    public async Task<User> GetByIdAsync(long id)
    {
        var result = await _userRepository.GetByIdAsync(id);

        return result;
    }

    public async Task<User> UpdateAsync(UserUpdateDto userDto)
    {
        var user = await _userRepository.GetByIdAsync(userDto.Id);

        user.Email = userDto.Email;
        user.FirstName = userDto.FirstName;
        user.LastName = userDto.LastName;
        user.Password = userDto.Password;
        user.Role = userDto.Role;

        var result = await _userRepository.UpdateAsync(user);
        return result;
    }
}
