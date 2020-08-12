using System;

namespace Extensions
{
    public static class Enum
    {
        public static object Parse(Type type, char c)
        {
            return System.Enum.Parse(type, c.ToString());
        }
        
        public static T Parse<T>(Type type, char c)
        {
            return (T)Parse(type, c);
        }
    }
}