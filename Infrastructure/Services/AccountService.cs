using Infrastructure.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AccountService
{
    private readonly DbContext _dbContext;
    private readonly UserManager<UserEntity> _userManager;

    public AccountService(DbContext dbContext, UserManager<UserEntity> userManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    //public async Task<bool> UpdateUserAsync(UserEntity user)
    //{
    //    _dbContext.Users.Add(user);
    //}
}
