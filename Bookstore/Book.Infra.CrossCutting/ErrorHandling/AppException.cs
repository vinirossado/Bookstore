using System.Globalization;
using static System.String;

namespace Book.Infra.CrossCutting.ErrorHandling;

public class AppException : Exception
{
    public AppException() : base() { }
    
    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args) : base(Format(CultureInfo.CurrentCulture, message, args))
    {
        
    }
}