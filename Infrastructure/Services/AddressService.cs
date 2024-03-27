using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositiories;

namespace Infrastructure.Services;

public class AddressService(AddressRepository addressRepository)
{
    private readonly AddressRepository _addressRepository = addressRepository;

    /// <summary>
    /// To both get and / or create an address
    /// </summary>
    /// <param name="streetName"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <returns></returns>
    public async Task<ResponseResult> GetOrCreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var result = await GetAddressAsync(streetName, postalCode, city);
            if (result.StatusCode == StatusCodes.NOT_FOUND)
                result = await CreateAddressAsync(streetName, postalCode, city);

            return result;
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }

    /// <summary>
    /// only create address
    /// </summary>
    /// <param name="streetName"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <returns></returns>
    public async Task<ResponseResult> CreateAddressAsync(string streetName, string postalCode, string city)
    {
        try
        {
            var exists = await _addressRepository.OneExistsAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (exists != null)
            {
                var result = await _addressRepository.CreateOneAsync(AddressFactory.Create(streetName, postalCode, city));
                if (result.StatusCode == StatusCodes.OK)
                    return ResponseFactory.Ok(AddressFactory.Create((AddressEntity)result.ContentResult!));

                return result;
            }

            return exists!;
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }

    /// <summary>
    /// Get one address
    /// </summary>
    /// <param name="streetName"></param>
    /// <param name="postalCode"></param>
    /// <param name="city"></param>
    /// <returns></returns>
    public async Task<ResponseResult> GetAddressAsync(string streetName, string postalCode, string city)
    {
        try 
        {
            var result = await _addressRepository.GetOneAsync(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return result;
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }
}
