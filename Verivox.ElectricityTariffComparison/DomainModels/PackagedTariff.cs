using Verivox.ElectricityTariffComparison.Helpers;

namespace Verivox.ElectricityTariffComparison.DomainModels
{
    public class PackagedTariff : Tariff
    {
        /// <summary>
        /// the default included KW in the package 
        /// should not be less than 0
        /// </summary>
        public decimal IncludedKwh { get; private set; }

        /// <summary>
        /// base constructor to force clients providing the values 
        /// and do the validation
        /// </summary>
        /// <param name="name">name of tariff</param>
        /// <param name="baseCost"> tarrif base cost</param>
        /// <param name="additionalKwhCost"> tarrif additional cost</param>
        /// <param name="includedKwh">the default included KW in the package </param>
        public PackagedTariff(string name,
        decimal baseCost, decimal additionalKwhCost,
        decimal includedKwh)
        : base(name, ProductType.package, baseCost, additionalKwhCost)
        {
            AssertionConcern.AssertArgumentGreaterThanOrEqual(IncludedKwh, 0, "IncludedKwh");
            IncludedKwh = includedKwh;

        }

        // Override method to calculate the annual cost for the packaged tariff
        public override decimal CalculateAnnualCost(decimal consumption)
        {
            if (consumption <= IncludedKwh)
            {
                return BaseCost;
            }
            else
            {
                decimal additionalConsumptionCost = (consumption - IncludedKwh) * AdditionalKwhCost / 100;
                return BaseCost + additionalConsumptionCost;
            }
        }
    }
}
