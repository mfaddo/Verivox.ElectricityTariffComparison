using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verivox.ElectricityTariffComparison.DomainModels;
using Verivox.ElectricityTariffComparison.Services;

namespace Verivox.ElectricityTariffComparison.Tests.Services
{
    public class TarrifCalculatorService
    {
        private Mock<ITariffProvider> _mockTariffProvider;
        private ITarrifCalculator _tarrifCalculator;

        [SetUp]
        public void Setup()
        {
            _mockTariffProvider = new Mock<ITariffProvider>();
            _tarrifCalculator = new TarrifCalculator(_mockTariffProvider.Object);

            _mockTariffProvider.Setup(provider => provider.GetTariff()).Returns(new List<Tariff>
            {
                new BasicTariff("Product A" , 5,22),
                new PackagedTariff("Product B",800,30,4000)
              
            }) ;
        }

        [Test]
        public void CalculateTariffs_ReturnsCorrectResults()
        {
            // Arrange
            int consumption = 4500;

            // Act
            var results = _tarrifCalculator.Calculate(consumption).ToList();

            // Assert
            Assert.NotNull(results);
            Assert.That(results.Count, Is.EqualTo( 2));

            dynamic firstTariff = results[0];
            Assert.AreEqual("Product B", firstTariff.TariffName);
            Assert.AreEqual(950m, firstTariff.AnnualCost);

            dynamic secondTariff = results[1];
            Assert.AreEqual("Product A", secondTariff.TariffName);
            Assert.AreEqual(1050m, secondTariff.AnnualCost);
        }
    }
}
