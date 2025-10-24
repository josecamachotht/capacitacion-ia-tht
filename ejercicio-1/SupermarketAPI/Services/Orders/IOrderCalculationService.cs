using SupermarketAPI.Models.Orders;

namespace SupermarketAPI.Services.Orders
{
    public interface IOrderCalculationService
    {
        Task<OrderCalculationResult> CalculateTaxAndShippingCostAsync(Order order);
    }
}