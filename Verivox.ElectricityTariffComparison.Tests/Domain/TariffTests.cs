using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verivox.ElectricityTariffComparison.DomainModels;

namespace Verivox.ElectricityTariffComparison.Tests.Domain
{
    public class TariffTests
    {
        [Test]
        public void BasicTariff_CalculatesAnnualCostCorrectly()
        {
            // Arrange
            var tariff = new BasicTariff("Test", 5, 22);
         
            // Act
            var annualCost = tariff.CalculateAnnualCost(3500);

            // Assert
            
            Assert.That(annualCost , Is.EqualTo(830));
        }

        [Test]
        public void BasicTariff_NegativeConsumption_shouldTrowException()
        {
            // Arrange
            var tariff = new BasicTariff("Test", 5, 22);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(()=> tariff.CalculateAnnualCost(-5));
        }


        [Test]

        public void PackageTariff_CalculatesAnnualCostCorrectly_underIncluded()
        {
            // Arrange
            var tariff = new PackagedTariff("Test", 800, 30, 4000);

            // Act
            var annualCost = tariff.CalculateAnnualCost(3500);

            // Assert

            Assert.That(annualCost, Is.EqualTo(800));
        }

        [Test]
        public void PackageTariff_CalculatesAnnualCostCorrectly_AboveIncluded()
        {
            // Arrange
            var tariff = new PackagedTariff("Test", 800, 30, 4000);

            // Act
            var annualCost = tariff.CalculateAnnualCost(4500);

            // Assert

            Assert.That(annualCost, Is.EqualTo(950));
        }

        [Test]
        public void PackageTariff_NegativeConsumption_shouldTrowException()
        {
            // Arrange
            var tariff = new PackagedTariff("Test",800, 30,4000);

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => tariff.CalculateAnnualCost(-5));
        }
    }
}
