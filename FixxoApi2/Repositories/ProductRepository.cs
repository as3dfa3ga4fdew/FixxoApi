using FixxoApi2.Contexts;
using FixxoApi2.Models.Dtos;
using FixxoApi2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FixxoApi2.Repositories
{
    public class ProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductMinimalResponse>> GetByTagIdCountAsync(int id, int count)
        {
            return await _context.Products.Include(x => x.Tag).Where(x => x.Tag.Id == id).Take(count).Select(x => (ProductMinimalResponse)x).ToListAsync();
        }

        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            return await _context.Products.Include(x => x.Tag).Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductMinimalResponse>> GetByTagAsync(string tag)
        {
            try
            {
                return await _context.Products.Include(x => x.Tag).Where(x => x.Tag.Tag == tag).Select(x => (ProductMinimalResponse)x).ToListAsync();
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                return null;
            }
            
        }

        public async Task<IEnumerable<ProductMinimalResponse>> GetByTagIdAsync(int tagId)
        {
            try
            {
                return await _context.Products.Include(x => x.Tag).Where(x => x.Tag.Id == tagId).Select(x => (ProductMinimalResponse)x).ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public async Task<ProductResponse> CreateAsync(ProductEntity entity)
        {
            try
            {
                await _context.Products.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
