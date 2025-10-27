using SupermarketAPI.Models;

namespace SupermarketAPI.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product?> UpdateAsync(int id, Product product);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Product>> GetByCategoryAsync(string category);
        Task<Product?> GetByBarcodeAsync(string barcode);
        Task<bool> ExistsAsync(int id);
    }
}