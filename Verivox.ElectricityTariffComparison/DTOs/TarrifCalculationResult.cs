namespace Verivox.ElectricityTariffComparison.DTOs
{
    /// <summary>
    /// DTO for Tarrif annula cost result
    /// </summary>
    public record TarrifCalculationResult
        (string TariffName 
        , decimal AnnualCost);
    
}
