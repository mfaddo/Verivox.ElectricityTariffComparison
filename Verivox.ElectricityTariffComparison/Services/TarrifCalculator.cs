using System.Linq;
using Verivox.ElectricityTariffComparison.DTOs;
using Verivox.ElectricityTariffComparison.Helpers;

namespace Verivox.ElectricityTariffComparison.Services
{
    public class TarrifCalculator : ITarrifCalculator
    {
        private readonly ITariffProvider _tariffProvider;
        public TarrifCalculator(ITariffProvider tariffProvider)
        {
            _tariffProvider = tariffProvider;
        }


        public IEnumerable<TarrifCalculationResult> Calculate(decimal consumption)
        {
            AssertionConcern.AssertArgumentGreaterThanOrEqual(consumption, 0, "consumption");
            return _tariffProvider.
                 GetTariff()
                 .Select(tariff =>
                     new TarrifCalculationResult(tariff.Name,
                     tariff.CalculateAnnualCost(consumption)))
                 .OrderBy(result => result.AnnualCost)
                 .ToList();
        }
    }
}
