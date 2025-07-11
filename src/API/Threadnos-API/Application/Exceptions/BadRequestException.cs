namespace Threadnos_API.Application.Exceptions
{
    public class BadRequestException : AppLayerException
    {
        public BadRequestException(string message)
            : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        public BadRequestException(string entityName, object key)
            : base($"Invalid request related to entity '{entityName}' with key '{key}'.")
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
