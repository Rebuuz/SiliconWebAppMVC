using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ResponseFactory
{
    
    public static ResponseResult Ok()
    {
        return new ResponseResult
        {
            Message = "Succeeded",
            StatusCode = StatusCodes.OK,
        };
    }

    public static ResponseResult Ok(object obj, string? message = null)
    {
        return new ResponseResult
        {
            ContentResult = obj,
            Message = message ?? "Succeeded",
            StatusCode = StatusCodes.OK,
        };
    }

    public static ResponseResult ERROR(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Failed",
            StatusCode = StatusCodes.ERROR,
        };
    }

    public static ResponseResult NotFound(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Not Found",
            StatusCode = StatusCodes.NOT_FOUND,
        };
    }

    public static ResponseResult Exists(string? message = null)
    {
        return new ResponseResult
        {
            Message = message ?? "Exists",
            StatusCode = StatusCodes.EXISTS,
        };
    }
}
