using SupermarketAPI.DTOs;
using SupermarketAPI.Models;
using SupermarketAPI.Repositories;

namespace SupermarketAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponseDto>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(MapToResponseDto);
        }

        public async Task<ProductResponseDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product != null ? MapToResponseDto(product) : null;
        }

        public async Task<ProductResponseDto> CreateProductAsync(CreateProductDto createProductDto)
        {
            var product = MapToProduct(createProductDto);
            var createdProduct = await _productRepository.CreateAsync(product);
            return MapToResponseDto(createdProduct);
        }

        public async Task<ProductResponseDto?> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            var product = MapToProduct(updateProductDto);
            var updatedProduct = await _productRepository.UpdateAsync(id, product);
            return updatedProduct != null ? MapToResponseDto(updatedProduct) : null;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseDto>> GetProductsByCategoryAsync(string category)
        {
            var products = await _productRepository.GetByCategoryAsync(category);
            return products.Select(MapToResponseDto);
        }

        public async Task<ProductResponseDto?> GetProductByBarcodeAsync(string barcode)
        {
            var product = await _productRepository.GetByBarcodeAsync(barcode);
            return product != null ? MapToResponseDto(product) : null;
        }

        private static ProductResponseDto MapToResponseDto(Product product)
        {
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                Stock = product.Stock,
                Barcode = product.Barcode,
                CreatedAt = product.CreatedAt,
                UpdatedAt = product.UpdatedAt,
                IsActive = product.IsActive
            };
        }

        private static Product MapToProduct(CreateProductDto createProductDto)
        {
            return new Product
            {
                Name = createProductDto.Name,
                Description = createProductDto.Description,
                Price = createProductDto.Price,
                Category = createProductDto.Category,
                Stock = createProductDto.Stock,
                Barcode = createProductDto.Barcode
            };
        }

        private static Product MapToProduct(UpdateProductDto updateProductDto)
        {
            return new Product
            {
                Name = updateProductDto.Name,
                Description = updateProductDto.Description,
                Price = updateProductDto.Price,
                Category = updateProductDto.Category,
                Stock = updateProductDto.Stock,
                Barcode = updateProductDto.Barcode,
                IsActive = updateProductDto.IsActive
            };
        }
    }
}