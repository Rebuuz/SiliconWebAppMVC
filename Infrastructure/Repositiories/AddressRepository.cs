using Infrastructure.Context;
using Infrastructure.Entities;

namespace Infrastructure.Repositiories;

public class AddressRepository(DataContext context) : BaseRepo<AddressEntity>(context)
{
    private readonly DataContext _context = context;

}
