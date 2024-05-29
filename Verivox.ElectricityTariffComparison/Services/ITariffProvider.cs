using Verivox.ElectricityTariffComparison.DomainModels;

namespace Verivox.ElectricityTariffComparison.Services
{
    public interface ITariffProvider
    {
        IEnumerable<Tariff> GetTariff();
    }
}
