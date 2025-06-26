using System.Net;

namespace Threadnos_API.Application.Exceptions
{
    public abstract class AppLayerException : Exception
    {
        public HttpStatusCode StatusCode;

        protected AppLayerException(string message) : base(message) { }

        protected AppLayerException(string message, Exception innerException)
            : base(message, innerException) { }
    }

}
