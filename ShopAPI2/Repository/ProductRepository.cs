using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopAPI2.Data;
using ShopAPI2.Models;
using ShopAPI2.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopAPI2.Repository
{
    public class ProductRepository :IProductRepository
    {
        private readonly ShopContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(ShopContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProductModel>> GetAll()
        {
            var records = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductModel>>(records);
        }
        public async Task<ProductModel> GetById(int productId)
        {
            var book = await _context.Products.FindAsync(productId);
            return _mapper.Map<ProductModel>(book);
        }
        public async Task<int> Add(ProductModel pmodel)
        {
            var field = new Products()
            {
                Name = pmodel.Name,
                Price = pmodel.Price,
                Quantity = pmodel.Quantity,
                Description = pmodel.Description,
                UserId = pmodel.UserId,
            };

            _context.Products.Add(field);
            await _context.SaveChangesAsync();
            return field.Id;
        }

        public async Task Update(int id, ProductModel pmodel)
        {
            var field = new Products()
            {
                Id = id,
                Name = pmodel.Name,
                Price = pmodel.Price,
                Quantity = pmodel.Quantity,
                Description = pmodel.Description,
                UserId = pmodel.UserId,
            };

            _context.Products.Update(field);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var field = new Products() { Id = id };
            _context.Products.Remove(field);
            await _context.SaveChangesAsync();
        }

    }
}
