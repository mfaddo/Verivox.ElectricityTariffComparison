namespace Verivox.ElectricityTariffComparison.Helpers
{
    public static class AssertionConcern
    {
        /// <summary>
        /// A global method whcih make sure value is greater than or equal the minimum
        /// </summary>
        /// <param name="value">the value you need to be bigger</param>
        /// <param name="minimum">the minimum that provided value should not be lower </param>
        /// <param name="argument">the argument name you need to show in exception message</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void AssertArgumentGreaterThanOrEqual(decimal value, decimal minimum, string argument)
        {
            if (value < minimum)
            {
                throw new ArgumentOutOfRangeException(argument,$"{argument} cannot be negative.");
            }
        }

        /// <summary>
        /// A global method which make sure the provided string is not null
        /// </summary>
        /// <param name="object1">the string you need to be not null</param>
        /// <param name="argument">the argument name you need to show in exception message</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void AssertArgumentNotNullString(string object1, string argument)
        {
            if (string.IsNullOrEmpty(object1))
            {
                throw new ArgumentNullException(argument);
            }
        }
    }
}
