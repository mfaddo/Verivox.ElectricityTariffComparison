using Verivox.ElectricityTariffComparison.DTOs;

namespace Verivox.ElectricityTariffComparison.Services
{
    public interface ITarrifCalculator
    {
        IEnumerable<TarrifCalculationResult> Calculate(decimal consumption);
    }
}
