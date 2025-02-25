namespace UpBank.Api;

public class UpApiException : Exception
{
    public UpApiException()
        : base()
    {
        this.Errors = Array.Empty<UpError>();
    }

    public UpApiException(string message)
        : base(message)
    {
        this.Errors = Array.Empty<UpError>();
    }

    public UpApiException(string message, Exception inner)
        : base(message, inner)
    {
        this.Errors = Array.Empty<UpError>();
    }

    public UpApiException(string message, IEnumerable<UpError> errors)
        : base(message)
    {
        this.Errors = errors.ToList();
    }

    public IEnumerable<UpError> Errors { get; init; }
}
