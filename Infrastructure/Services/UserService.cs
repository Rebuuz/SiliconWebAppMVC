using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositiories;

namespace Infrastructure.Services;

public class UserService(UserRepository userRepository, AddressService addressService)
{
    /// <summary>
    /// using both user repo and address service to able to do both things
    /// </summary>
    private readonly UserRepository _userRepository = userRepository;
    private readonly AddressService _addressService = addressService;

    /// <summary>
    /// create a user
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    //public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
    //{
    //    //try
    //    //{
    //    //    var exists = await _userRepository.OneExistsAsync(x => x.Email == model.EmailAddress);
    //    //    if (exists.StatusCode == StatusCodes.EXISTS)
    //    //        return exists;

    //    //        var result = await _userRepository.CreateOneAsync(UserFactory.Create(model));

    //    //    if (result.StatusCode != StatusCodes.OK)
    //    //        return result;

    //    //        return ResponseFactory.Ok("User created successfully");
            
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    return ResponseFactory.ERROR(ex.Message);
    //    //}
    //}

    public async Task<ResponseResult> SignInUserAsync(SignInModel model)
    {
        try
        {
            ///find the user in the database by email and check if the password is correct
            var result = await _userRepository.GetOneAsync(x => x.Email == model.EmailAddress);
            if (result.StatusCode == StatusCodes.OK && result.ContentResult != null)
            {
                ///convert object to user entity
                var userEntity = (UserEntity)result.ContentResult;

                //if (PasswordHasher.ValidateSecurePassword(model.Password, userEntity.Password, userEntity.SecurityKey))
                    return ResponseFactory.Ok();


            }

            ///if the provided information is not correct, do this 
            return ResponseFactory.ERROR("Incorrect email address or password");

        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }
}
