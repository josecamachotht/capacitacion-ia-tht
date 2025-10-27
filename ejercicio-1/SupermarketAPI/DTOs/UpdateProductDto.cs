using System.ComponentModel.DataAnnotations;

namespace SupermarketAPI.DTOs
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Description { get; set; }
        
        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que 0")]
        public decimal Price { get; set; }
        
        [Required(ErrorMessage = "La categoría es requerida")]
        [StringLength(50, ErrorMessage = "La categoría no puede exceder 50 caracteres")]
        public string Category { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "El stock es requerido")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }
        
        [StringLength(50, ErrorMessage = "El código de barras no puede exceder 50 caracteres")]
        public string? Barcode { get; set; }
        
        public bool IsActive { get; set; } = true;
    }
}