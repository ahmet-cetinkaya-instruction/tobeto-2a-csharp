namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessException : Exception // is-a relationship
{
    public BusinessException(string message) : base(message)
    {
    }
}
