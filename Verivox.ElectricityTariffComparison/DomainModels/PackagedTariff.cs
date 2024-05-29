using Verivox.ElectricityTariffComparison.Helpers;

namespace Verivox.ElectricityTariffComparison.DomainModels
{
    public class PackagedTariff : Tariff
    {
        public decimal IncludedKwh { get; private set; }

        public PackagedTariff(string name,
        decimal baseCost, decimal additionalKwhCost,
        decimal includedKwh)
        : base(name, ProductType.package, baseCost, additionalKwhCost)
        {
            AssertionConcern.AssertArgumentGreaterThanOrEqual(IncludedKwh, 0, "IncludedKwh");
            IncludedKwh = includedKwh;

        }
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
