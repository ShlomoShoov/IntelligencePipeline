

using System.Security.Cryptography.X509Certificates;

namespace IntelligencePipeline.Exceptions
{
    public class MismatchedObjectException : Exception
    {
        public MismatchedObjectException(string message) : base(message) { }
    }
}
