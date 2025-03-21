using Microsoft.EntityFrameworkCore;
using OnlineFoodDeliverySystem.Data;
using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly FoodDbContext _context;

        public AdminRepository(FoodDbContext context)
        {
            _context = context;
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _context.Admins.AddAsync(admin);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAdminAsync(int id)
        {
            var adminToDelete = await _context.Admins.FindAsync(id);
            if (adminToDelete != null)
            {
                _context.Admins.Remove(adminToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task UpdateAdminAsync(int id, Admin admin)
        {
            var adminToUpdate = await _context.Admins.FindAsync(id);
            if (adminToUpdate != null)
            {
                adminToUpdate.AdminName = admin.AdminName;
                adminToUpdate.AdminEmail = admin.AdminEmail;
                adminToUpdate.AdminPassword = admin.AdminPassword;
                adminToUpdate.RoleID = admin.RoleID;
                _context.Admins.Update(adminToUpdate);
                await _context.SaveChangesAsync();
            }
        }
    }
}