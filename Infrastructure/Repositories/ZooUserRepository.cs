using Domain.Model;
using Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public class ZooUserRepository : IZooUserRepository
    {
        private readonly ZooDbContext _context;
        public ZooUserRepository(ZooDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ZooUser>> GetAllUsersAsync()
        {
            return await _context.AnimalOwners.ToListAsync();
        }

        public async Task<ZooUser> GetUserByIdAsync(int id)
        {
            return await _context.AnimalOwners.FindAsync(id);
        }

        public async Task<ZooUser> GetUserByLoginAsync(string login)
        {
            return await _context.AnimalOwners.FirstOrDefaultAsync(u => u.Login == login);
        }

        public async Task AddUserAsync(ZooUser user)
        {
            await _context.AnimalOwners.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(ZooUser user)
        {
            _context.AnimalOwners.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.AnimalOwners.FindAsync(id);
            if (user != null)
            {
                _context.AnimalOwners.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
