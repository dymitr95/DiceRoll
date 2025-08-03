namespace DiceRollBackend.Application.DTOs.API;

public class ApiResponse<T>
{
    public int StatusCode { get; set; }
    public string Status { get; set; } = "Success";
    public string? Message { get; set; }
    public T? Data { get; set; }
    
    public static ApiResponse<T> Success(T data, string? message = null, int statusCode = 200)
    {
        return new ApiResponse<T>
        {
            Data = data,
            Message = message,
            StatusCode = statusCode,
            Status = "Success"
        };
    }

    public static ApiResponse<T> Fail(string message, int statusCode = 400)
    {
        return new ApiResponse<T>
        {
            Data = default,
            Message = message,
            StatusCode = statusCode,
            Status = "Error"
        };
    }
}