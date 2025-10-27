using SupermarketAPI.Models.Orders;

namespace SupermarketAPI.Services.Orders
{
    public class OrderCalculationService : IOrderCalculationService
    {
        private readonly ILogger<OrderCalculationService> _logger;

        public OrderCalculationService(ILogger<OrderCalculationService> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Calculates total tax and shipping cost for a given Order object.
        /// Rules:
        /// 1. Tax is 8% for local customers, 15% for international.
        /// 2. Shipping is a flat $10, but free for orders with a total greater than or equal to $200.
        /// 3. A 5% discount is applied only to the price of items with a 'promotional' flag.
        /// 4. This method must be asynchronous to allow for potential external API calls in the future.
        /// </summary>
        public async Task<OrderCalculationResult> CalculateTaxAndShippingCostAsync(Order order)
        {
            _logger.LogInformation("Starting tax and shipping calculation for Order {OrderId}", order.OrderId);

            // Validar que la orden no sea nula y tenga items
            if (order == null || !order.Items.Any())
            {
                throw new ArgumentException("Order cannot be null or empty");
            }

            var result = new OrderCalculationResult();

            // Calcular el subtotal base
            result.SubTotal = order.OrderTotal;

            // Aplicar descuento del 5% a productos promocionales
            decimal promotionalDiscount = 0;
            foreach (var item in order.Items.Where(i => i.ProductType == ProductType.Promotional))
            {
                promotionalDiscount += item.ItemTotal * 0.05m;
            }
            result.DiscountAmount = promotionalDiscount;

            // Calcular el subtotal después del descuento
            decimal subtotalAfterDiscount = result.SubTotal - result.DiscountAmount;

            // Calcular impuestos según la ubicación del cliente
            decimal taxRate = order.CustomerLocation switch
            {
                CustomerLocation.Local => 0.08m,        // 8% para clientes locales
                CustomerLocation.International => 0.15m, // 15% para clientes internacionales
                _ => throw new ArgumentException("Invalid customer location")
            };

            result.TaxAmount = subtotalAfterDiscount * taxRate;

            // Calcular costo de envío
            // Envío gratuito para órdenes >= $200
            if (subtotalAfterDiscount >= 200)
            {
                result.ShippingCost = 0; // Envío gratuito
            }
            else
            {
                result.ShippingCost = 10; // Costo fijo de envío
            }

            // Calcular el total final
            result.FinalTotal = subtotalAfterDiscount + result.TaxAmount + result.ShippingCost;

            // Generar detalles del cálculo
            result.CalculationDetails = $"Subtotal: ${result.SubTotal:F2}, " +
                                      $"Discount: ${result.DiscountAmount:F2}, " +
                                      $"Tax ({(taxRate * 100):F0}%): ${result.TaxAmount:F2}, " +
                                      $"Shipping: ${result.ShippingCost:F2}, " +
                                      $"Final Total: ${result.FinalTotal:F2}";

            _logger.LogInformation("Tax and shipping calculation completed for Order {OrderId}. Final total: {FinalTotal}", 
                order.OrderId, result.FinalTotal);

            // Simular llamada asíncrona para futuras integraciones con APIs externas
            await Task.Delay(50);

            return result;
        }
    }
}