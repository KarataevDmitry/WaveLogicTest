using System;
using System.Runtime.Serialization;

namespace WaveLogicTestWinForms.Exceptions
{
    [Serializable]
    public class NoDepthPatternProvidedException : Exception
    {
        public NoDepthPatternProvidedException()
        {
        }

        public NoDepthPatternProvidedException(string message) : base(message)
        {
        }

        public NoDepthPatternProvidedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoDepthPatternProvidedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
