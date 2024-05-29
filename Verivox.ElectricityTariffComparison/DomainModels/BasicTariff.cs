namespace Verivox.ElectricityTariffComparison.DomainModels
{
    public class BasicTariff :Tariff
    {    
        public BasicTariff(string name,
              decimal baseCost, decimal additionalKwhCost)
       : base(name, ProductType.basic,baseCost,additionalKwhCost)
        {

        }

        // Override method to calculate the annual cost for the basic electricity tariff
        public override decimal CalculateAnnualCost(decimal consumption)
        {
            decimal baseCostPerYear = BaseCost * 12;
            decimal consumptionCost = consumption * AdditionalKwhCost / 100;
            return baseCostPerYear + consumptionCost;
        }
    }

}
