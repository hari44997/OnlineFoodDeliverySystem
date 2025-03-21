using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task AddAdminAsync(Admin admin)
        {
            await _adminRepository.AddAdminAsync(admin);
        }

        public async Task DeleteAdminAsync(int id)
        {
            Admin deleteAdmin = await _adminRepository.GetAdminByIdAsync(id);
            if (deleteAdmin == null)
            {
                throw new NotFoundException($"Admin wiht id {id} does not exists");
            }
            await _adminRepository.DeleteAdminAsync(id);
        }

        public async Task<Admin> GetAdminByIdAsync(int id)
        {
            var getAdmin = await _adminRepository.GetAdminByIdAsync(id);
            if (getAdmin == null)
            {
                throw new NotFoundException($"Admin with id {id} does not exists");
            }
            return getAdmin;
        }

        public async Task<IEnumerable<Admin>> GetAllAdminsAsync()
        {
            var getallAdmins = await _adminRepository.GetAllAdminsAsync();
            return getallAdmins.ToList();
        }

        public async Task UpdateAdminAsync(int id, Admin admin)
        {
            Admin updateAdmin = await _adminRepository.GetAdminByIdAsync(id);
            if (updateAdmin == null)
            {
                throw new NotFoundException($"Admin wiht id {id} does not exists");
            }
            await _adminRepository.UpdateAdminAsync(id, admin);
        }
    }
}
