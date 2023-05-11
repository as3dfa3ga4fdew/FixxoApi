using FixxoApi2.Contexts;
using FixxoApi2.Models.Dtos;
using FixxoApi2.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace FixxoApi2.Repositories
{
    public class TagRepository
    {
        private readonly DataContext _context;

        public TagRepository(DataContext context) 
        { 
            _context = context;
        }

        public async Task DeleteAsync()
        {
            await _context.Tags.ExecuteDeleteAsync();
        }

        public async Task<TagResponse> GetByIdAsync(int id)
        {
            return await _context.Tags.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TagResponse>> GetAllAsync()
        {
            return await _context.Tags.Select(x => (TagResponse)x).ToListAsync();
        }

        public async Task<TagResponse> CreateAync(TagEntity entity)
        {
            try
            {
                await _context.Tags.AddAsync(entity);
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
