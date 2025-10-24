namespace SupermarketAPI.Models.Orders
{
    public enum CustomerLocation
    {
        Local,
        International
    }

    public enum ProductType
    {
        Normal,
        Promotional
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public ProductType ProductType { get; set; }
        public decimal ItemTotal => Price * Quantity;
    }

    public class Order
    {
        public int OrderId { get; set; }
        public CustomerLocation CustomerLocation { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal OrderTotal => Items.Sum(item => item.ItemTotal);
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }

    public class OrderCalculationResult
    {
        public decimal SubTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal FinalTotal { get; set; }
        public string CalculationDetails { get; set; } = string.Empty;
    }
}