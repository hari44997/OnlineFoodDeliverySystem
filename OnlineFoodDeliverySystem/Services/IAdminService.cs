﻿using OnlineFoodDeliverySystem.Models;

namespace OnlineFoodDeliverySystem.Services
{
    public interface IAdminService
    {
        Task<IEnumerable<Admin>> GetAllAdminsAsync();
        Task<Admin> GetAdminByIdAsync(int id);
        Task AddAdminAsync(Admin admin);
        Task UpdateAdminAsync(int id, Admin admin);
        Task DeleteAdminAsync(int id);
    }
}
