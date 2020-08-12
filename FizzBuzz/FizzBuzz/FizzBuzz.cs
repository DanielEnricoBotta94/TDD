namespace FizzBuzz
{
    public static class FizzBuzz
    {
        public static string Convert(int input)
        {
            var output = "";
            if (input % 3 == 0)
                output = "Fizz";
            if (input % 5 == 0)
                output = $"{output}Buzz";
            return string.IsNullOrEmpty(output)
                ? input.ToString()
                : output ;
        }
    }
}