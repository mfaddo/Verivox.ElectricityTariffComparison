using Verivox.ElectricityTariffComparison.DomainModels;

namespace Verivox.ElectricityTariffComparison.Services
{
    public class FromStaticListTariff : ITariffProvider
    {
        private readonly List<Tariff> _tariffs;
        public FromStaticListTariff()
        {
            _tariffs = new List<Tariff>
                {
                    new BasicTariff ("Product A",5,22),
                    new PackagedTariff("Product B",800,30,4000)
                };
        }
        public IEnumerable<Tariff> GetTariff()
                    =>_tariffs; 
        
    }
}
