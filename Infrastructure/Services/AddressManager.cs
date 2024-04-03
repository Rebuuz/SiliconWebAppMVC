
using Infrastructure.Context;
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager(DataContext context)
{
    private readonly DataContext _context = context;

    public async Task<AddressEntity> GetAddressAsync(int id)
    {
        var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == id);
        return addressEntity!;
    }

    public async Task<bool> CreateAddressAsync(AddressEntity entity)
    {
        try
        {
            _context.Addresses.Add(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }


    public async Task<int> GetOrCreateAddressAsync(string addressline1, string? addressline2, string postalcode, string city)
    {
        try
        {
            var existingAddress = await _context.Addresses.FirstOrDefaultAsync(x => x.AddressOne == addressline1 &&  x.AddressTwo == addressline2 && x.PostalCode == postalcode && x.City == city);
            if (existingAddress != null)
            {
                return existingAddress.Id;
            }
            else
            {
                var entity = new AddressEntity
                {
                    AddressOne = addressline1,
                    AddressTwo = addressline2,
                    PostalCode = postalcode,
                    City = city

                };
                var newAddress = _context.Addresses.Add(entity);
                await _context.SaveChangesAsync();
                return entity.Id;


            }

        }
        catch (Exception)
        {

            return 0;
        }
    }




    public async Task<bool> UpdateAddressAsync(AddressEntity entity)
    {
        var existing = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (existing != null)
        {
            _context.Entry(existing).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        return false;
    }
}
