namespace Sharp.Extensions
{
    public static class IntExtension
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }
    }
}