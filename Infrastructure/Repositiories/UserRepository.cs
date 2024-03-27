using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositiories;

public class UserRepository(DataContext context) : BaseRepo<UserEntity>(context)
{
    private readonly DataContext _context = context;

    /// <summary>
    /// override to include addresses too
    /// </summary>
    /// <returns></returns>
    public override async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<UserEntity> result = await _context.Users
                .Include(i => i.Address)
                .ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
        
    }


    /// <summary>
    /// override to include addresses too 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public override async Task<ResponseResult> GetOneAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<UserEntity>()
                .Include(i => i.Address)
                .FirstOrDefaultAsync(predicate);
            if (result == null)
            {
                return ResponseFactory.NotFound();
            }
            else
            {
                return ResponseFactory.Ok(result);
            }
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }
}
