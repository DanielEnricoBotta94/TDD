using System.Text.RegularExpressions;

namespace Brackets
{
    public class Brackets
    {
        public static bool IsValid(string empty)
        {
            if(string.IsNullOrEmpty(empty))
                return true;

            var open = 0;
            var closed = 0;

            foreach (var t in empty)
            {
                if (t == '[')
                    open++;
                else if (t == ']')
                    closed++;

                if (closed > open)
                    return false;
            }

            return true;
        }
    }
}