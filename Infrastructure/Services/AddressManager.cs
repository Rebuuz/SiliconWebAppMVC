
using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddressManager(DbContext context)
{
    private readonly DbContext _context = context;

    public async Task<AddressEntity> GetAddressAsync(int id)
    {
        var addressEntity = await _context.Addresses.FirstOrDefaultAsync(x => x.id == Id)
    }
}
