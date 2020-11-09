using System;
using System.Runtime.Serialization;

namespace Task5
{
    [Serializable]
    internal class GameTaskException : Exception
    {
        public GameTaskException()
        {
        }

        public GameTaskException(string message) : base(message)
        {
        }

        public GameTaskException(string message, 
            Exception innerException) : base(message, innerException)
        {
        }

        protected GameTaskException(SerializationInfo info, 
            StreamingContext context) : base(info, context)
        {
        }
    }
}