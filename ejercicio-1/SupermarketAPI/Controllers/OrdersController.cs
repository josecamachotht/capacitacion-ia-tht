using Microsoft.AspNetCore.Mvc;
using SupermarketAPI.Models.Orders;
using SupermarketAPI.Services.Orders;

namespace SupermarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderCalculationService _orderCalculationService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderCalculationService orderCalculationService, ILogger<OrdersController> logger)
        {
            _orderCalculationService = orderCalculationService;
            _logger = logger;
        }

        /// <summary>
        /// Calcula los impuestos y costos de envío para una orden
        /// </summary>
        /// <param name="order">Orden a procesar</param>
        /// <returns>Resultado del cálculo con desglose de costos</returns>
        [HttpPost("calculate")]
        public async Task<ActionResult<OrderCalculationResult>> CalculateOrderCosts([FromBody] Order order)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _orderCalculationService.CalculateTaxAndShippingCostAsync(order);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex, "Invalid order data provided");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating order costs");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /// <summary>
        /// Endpoint de ejemplo para generar una orden de prueba
        /// </summary>
        /// <returns>Orden de ejemplo</returns>
        [HttpGet("sample")]
        public ActionResult<Order> GetSampleOrder()
        {
            var sampleOrder = new Order
            {
                OrderId = 1001,
                CustomerLocation = CustomerLocation.Local,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = 1,
                        ProductName = "Leche Entera 1L",
                        Price = 2.50m,
                        Quantity = 2,
                        ProductType = ProductType.Normal
                    },
                    new OrderItem
                    {
                        ProductId = 2,
                        ProductName = "Pan Integral - Promoción",
                        Price = 3.25m,
                        Quantity = 3,
                        ProductType = ProductType.Promotional
                    }
                }
            };

            return Ok(sampleOrder);
        }
    }
}