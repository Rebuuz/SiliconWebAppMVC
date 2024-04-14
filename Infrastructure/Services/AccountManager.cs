using Infrastructure.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using System.Security.Claims;

namespace Infrastructure.Services;

public class AccountManager(DbContext dbContext, UserManager<UserEntity> userManager, IConfiguration configuration)
{
    private readonly DbContext _dbContext = dbContext;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly IConfiguration _configuration = configuration;

    public async Task<bool> UploadProfileImageAsync(ClaimsPrincipal user, IFormFile file)
    {
        try
        {
            if (user != null && file != null && file.Length != 0)
            {
                var userEntity = await _userManager.GetUserAsync(user);
                if (userEntity != null)
                {
                    ///Makes sure image has a unique name
                    var fileName = $"p_{userEntity.Id}_{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                    ///finds the path
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), _configuration["FileUploadPath"]!, fileName);

                    using var fileStream = new FileStream(filePath, FileMode.Create);

                    await file.CopyToAsync(fileStream);

                    ///save to database with only the filename
                    userEntity.ProfileImage = fileName;
                    _dbContext.Update(userEntity);
                    await _dbContext.SaveChangesAsync();


                    return true;
                }
            }

        }
        catch (Exception ex) 
        { 
            Debug.WriteLine(ex.Message); 
        }
        ///unsuccessful
        return false;
    }
}
