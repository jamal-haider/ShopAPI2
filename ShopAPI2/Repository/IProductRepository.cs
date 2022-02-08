using ShopAPI2.Data;
using ShopAPI2.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI2.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> GetAll();
        Task<ProductModel> GetById(int productId);
        Task<int> Add(ProductModel pmodel);
        Task Update(int id, ProductModel pmodel);
        Task Delete(int id);
    }
}
