namespace Verivox.ElectricityTariffComparison.Helpers
{
    public static class AssertionConcern
    {
        public static void AssertArgumentGreaterThanOrEqual(decimal value, decimal minimum, string argument)
        {
            if (value < minimum)
            {
                throw new ArgumentOutOfRangeException(argument,$"{argument} cannot be negative.");
            }
        }

        public static void AssertArgumentNotNullString(string object1, string argument)
        {
            if (string.IsNullOrEmpty(object1))
            {
                throw new ArgumentNullException(argument);
            }
        }
    }
}
