using System;

namespace CorePub.Repositories.Common
{
    public class AlreadyExistException : Exception
    {
        public AlreadyExistException(string message): base(message)
        {
        }
    }

    
}
