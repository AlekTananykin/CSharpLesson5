using System;
using System.Runtime.Serialization;

namespace Task4
{
    [Serializable]
    internal class PupilAccountException : Exception
    {
        public PupilAccountException()
        {
        }

        public PupilAccountException(string message) : base(message)
        {
        }

        public PupilAccountException(string message, 
            Exception innerException) : base(message, innerException)
        {
        }

        protected PupilAccountException(SerializationInfo info, 
            StreamingContext context) : base(info, context)
        {
        }
    }
}