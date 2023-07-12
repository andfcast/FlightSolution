namespace Flights.Utils
{
    public static class CurrencyConverter
    {
        public static double ConvertToCOP(double value) 
        {
            return value * 4160;
        }

        public static double ConvertToGBP(double value)
        {
            return value * 0.77;
        }
    }
}