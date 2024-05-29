using Verivox.ElectricityTariffComparison.Helpers;

namespace Verivox.ElectricityTariffComparison.DomainModels
{
    public abstract class Tariff
    {
        /// <summary>
        /// name of tariff should not be null
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// type of tariff (basic , package) 
        /// you can  add more tariff by adding more enum values
        /// </summary>
        public ProductType Type { get; private  set; }

        /// <summary>
        ///  Base cost for the included kWh not be less than zero
        /// </summary>
        public decimal BaseCost { get; private set; }

        /// <summary>
        /// Cost per kWh above the included kWh should not be less than zero
        /// </summary>
        public decimal AdditionalKwhCost { get; private set; }

        /// <summary>
        /// base constructor to force clients providing the values 
        /// and do the validation
        /// </summary>
        /// <param name="name">name of tariff</param>
        /// <param name="type">type of tariff (basic , package) </param>
        /// <param name="baseCost"> tarrif base cost</param>
        /// <param name="additionalKwhCost"> Cost per kWh above the included kWh should not be less than zero</param>
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

        /// <summary>
        ///Abstract method to calculate the annual cost based on 
        ///consumption
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns>the annual cost based on the tarrif type</returns>
        public abstract decimal CalculateAnnualCost
            (decimal consumption);
    }
}
