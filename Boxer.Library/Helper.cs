using System;

namespace B.Library
{
    public static class Helper
    {
        public static void ThrowIf(bool condition, string message = null)
        {
            if (condition) throw new Exception(message);
        }

        public static void ThrowIf<T>(bool condition, string message = null)
            where T : Exception
        {
            if (condition) throw (T)Activator.CreateInstance(typeof(T), message);
        }
    }
}
