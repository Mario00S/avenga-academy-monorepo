using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaApp.Domain.Entities;
using PizzaApp.Dtos.Users;
using PizzaApp.Services.Abstractions;
using PizzaApp.Shared.Exceptions;

namespace PizzaApp.Services.Implementations;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;
    private readonly ICurrentUser _currentUser;
    private readonly IMapper _mapper;

    public UserService(
        ICurrentUser currentUser,
        UserManager<User> userManager,
        IMapper mapper)
    {
        _currentUser = currentUser;
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<UserDto> GetCurrentUserAsync()
    {
        var user = await FindUserAsync(_currentUser.Id);
        return await ToUserDtoAsync(user);
    }

    public async Task ChangeCurrentUserPasswordAsync(ChangePasswordDto request)
    {
        var user = await FindUserAsync(_currentUser.Id);

        var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);

        ThrowIfFailed(result, "Changing the password failed.");
    }

    public async Task<UserDto> UpdateCurrentUserAsync(UpdateUserDto request)
    {
        var user = await FindUserAsync(_currentUser.Id);

        user.UserName = request.UserName;
        user.Email = request.Email;

        var result = await _userManager.UpdateAsync(user);

        ThrowIfFailed(result, "Updating the user failed.");

        return await ToUserDtoAsync(user);
    }

    public async Task DeleteCurrentUserAsync()
    {
        var user = await FindUserAsync(_currentUser.Id);
        var result = await _userManager.DeleteAsync(user);
        ThrowIfFailed(result, "Deleting the user failed.");
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var users = await _userManager.Users
            .AsNoTracking()
            .OrderBy(user => user.UserName)
            .ToListAsync();

        var userDtos = new List<UserDto>();
        foreach (var user in users)
        {
            userDtos.Add(await ToUserDtoAsync(user));
        }

        return userDtos;
    }

    public async Task<UserDto> GetByIdAsync(string id)
    {
        var user = await FindUserAsync(id);
        return await ToUserDtoAsync(user);
    }

    public async Task<UserDto> SetRoleAsync(string id, string role)
    {
        var user = await FindUserAsync(id);
        var currentRoles = await _userManager.GetRolesAsync(user);

        var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
        ThrowIfFailed(removeResult, "Changing the role failed.");

        var addResult = await _userManager.AddToRoleAsync(user, role);
        ThrowIfFailed(addResult, "Changing the role failed.");

        return await ToUserDtoAsync(user);
    }

    public async Task DeleteAsync(string id)
    {
        var user = await FindUserAsync(id);
        var result = await _userManager.DeleteAsync(user);
        ThrowIfFailed(result, "Deleting the user failed.");
    }

    private async Task<User> FindUserAsync(string id)
    {
        return await _userManager.FindByIdAsync(id)
            ?? throw new NotFoundException(nameof(User), id);
    }

    private static void ThrowIfFailed(IdentityResult result, string message)
    {
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(error => error.Description);
            throw new BadRequestException(message, errors);
        }
    }

    private async Task<UserDto> ToUserDtoAsync(User user)
    {
        var userDto = _mapper.Map<UserDto>(user);
        userDto.Roles = [.. await _userManager.GetRolesAsync(user)];
        return userDto;
    }
}
