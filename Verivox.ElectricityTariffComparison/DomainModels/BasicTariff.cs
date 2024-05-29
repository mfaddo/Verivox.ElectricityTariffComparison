namespace Verivox.ElectricityTariffComparison.DomainModels
{
    public class BasicTariff :Tariff
    {    
        public BasicTariff(string name,
              decimal baseCost, decimal additionalKwhCost)
       : base(name, ProductType.basic,baseCost,additionalKwhCost)
        {
           
        }
        public override decimal CalculateAnnualCost(decimal consumption)
        {
            decimal baseCostPerYear = BaseCost * 12;
            decimal consumptionCost = consumption * AdditionalKwhCost / 100;
            return baseCostPerYear + consumptionCost;
        }
    }

}
