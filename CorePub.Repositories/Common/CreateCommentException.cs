using System;

namespace CorePub.Repositories.Common
{
    [Serializable]
    internal class CreateCommentException : Exception
    {
        public CreateCommentException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
