namespace Threadnos_API.Application.Exceptions
{
    public class NotFoundException : AppLayerException
    {
        public NotFoundException(string entityName, object key)
            : base($"Entity '{entityName}' with key '{key}' was not found.") 
        {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }

}
