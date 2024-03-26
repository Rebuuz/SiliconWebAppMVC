

using Infrastructure.Context;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Infrastructure.Repositiories;

public abstract class BaseRepo<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;


    /// <summary>
    /// Create something, ex user. Using async/await
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<ResponseResult> CreateOneAsync(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return new ResponseResult
            {
                ContentResult = entity,
                Message = "Created successfully",
                StatusCode = StatusCodes.OK,
            };
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }

    /// <summary>
    /// Get all from the list
    /// </summary>
    /// <returns></returns>
    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }

    /// <summary>
    /// Get one async method
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual async Task<TEntity> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            return result!;
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }

    /// <summary>
    /// Update async method
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    public virtual async Task<TEntity> UpdateAsync(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            var entityToUpdate = await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
            if (entityToUpdate != null)
            {
                _context.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();

                return entityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine("Error :: " + ex.Message); }
        return null!;
    }

}
