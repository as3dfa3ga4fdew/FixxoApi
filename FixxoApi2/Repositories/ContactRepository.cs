using FixxoApi2.Contexts;
using FixxoApi2.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FixxoApi2.Repositories
{
    public class ContactRepository : ControllerBase
    {
        private readonly DataContext _context;

        public ContactRepository(DataContext context) 
        {
            _context = context;
        }

        public async Task CreateAsync(ContactEntity entity)
        {
            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return;
        }

    }
}
