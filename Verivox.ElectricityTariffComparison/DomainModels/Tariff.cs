using Verivox.ElectricityTariffComparison.Helpers;

namespace Verivox.ElectricityTariffComparison.DomainModels
{
    public abstract class Tariff
    {
        public string Name { get; private set; }
        public ProductType Type { get; private  set; }
        public decimal BaseCost { get; private set; }
        public decimal AdditionalKwhCost { get; private set; }
        public Tariff(string name, ProductType type , 
            decimal baseCost, 
            decimal additionalKwhCost)
        {
            AssertionConcern.AssertArgumentGreaterThanOrEqual(baseCost, 0, "baseCost");
            AssertionConcern.AssertArgumentGreaterThanOrEqual(additionalKwhCost, 0, "additionalKwhCost");
            AssertionConcern.AssertArgumentNotNullString(name, "name");          
            Name = name;
            Type = type;
            BaseCost = baseCost;
            AdditionalKwhCost = additionalKwhCost;
        }

        public abstract decimal CalculateAnnualCost
            (decimal consumption);
    }
}
