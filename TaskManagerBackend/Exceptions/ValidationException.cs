namespace TaskManagerBackend.Exceptions;

public class ValidationException : Exception
{
    public ValidationException() : base("Validation failed.")
    {
    }
    
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}