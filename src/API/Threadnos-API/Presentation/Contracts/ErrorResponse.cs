namespace Threadnos_API.Presentation.Contracts
{
    public class ErrorResponse
    {
        public int StatusCode { get; init; }
        public string Message { get; init; }

        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
