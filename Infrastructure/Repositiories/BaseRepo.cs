

using Infrastructure.Context;
using Infrastructure.Factories;
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
            return ResponseFactory.Ok(entity);
            
        }
        catch (Exception ex) 
        {
            return ResponseFactory.ERROR(ex.Message);
        }
        
    }

    /// <summary>
    /// Get all from the list
    /// </summary>
    /// <returns></returns>
    public virtual async Task<ResponseResult> GetAllAsync()
    {
        try
        {
            IEnumerable<TEntity> result = await _context.Set<TEntity>().ToListAsync();
            return ResponseFactory.Ok(result);
        }
        catch (Exception ex) 
        {
            return ResponseFactory.ERROR(ex.Message);
        } 
    }

    /// <summary>
    /// Get one async method
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual async Task<ResponseResult> GetOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
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

    /// <summary>
    /// Update async method
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="entity"></param>
    /// <returns></returns>

    public virtual async Task<ResponseResult> UpdateOneAsync(Expression<Func<TEntity, bool>> predicate, TEntity updatedEntity)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(updatedEntity);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok(result);
            }
            else
            {
                return ResponseFactory.NotFound();
            }
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }

    /// <summary>
    /// to delete one 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public virtual async Task<ResponseResult> DeleteOneAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().FirstOrDefaultAsync(predicate);
            if (result != null)
            {
                _context.Set<TEntity>().Remove(result);
                await _context.SaveChangesAsync();
                return ResponseFactory.Ok("Successfully removed");
            }
            else
            {
                return ResponseFactory.NotFound();
            }
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }

     /// <summary>
     /// if one exists 
     /// </summary>
     /// <param name="predicate"></param>
     /// <returns></returns>
    public virtual async Task<ResponseResult> OneExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var result = await _context.Set<TEntity>().AnyAsync(predicate);
            if (result)
            {
                return ResponseFactory.Exists();
            }
            else
            {
                return ResponseFactory.NotFound();
            }
        }
        catch (Exception ex)
        {
            return ResponseFactory.ERROR(ex.Message);
        }
    }

}
