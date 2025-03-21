using OnlineFoodDeliverySystem.Exceptions;
using OnlineFoodDeliverySystem.Models;
using OnlineFoodDeliverySystem.Repository;

namespace OnlineFoodDeliverySystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.ToList();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            User user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                throw new NotFoundException($"User with id {id} does not exists");
            }
            return user;
        }

        public async Task AddUserAsync(User user)
        {
            var Adduser = await _userRepository.GetUserByIdAsync(user.UserID);
            if (Adduser != null)
            {
                throw new AlreadyExistsException($"User with {user.UserID} already exists");
            }
            await _userRepository.AddUserAsync(user);

        }

        public async Task UpdateUserAsync(int id, User user)
        {
            var Updateuser = await _userRepository.GetUserByIdAsync(id);
            if (Updateuser == null)
            {
                throw new NotFoundException($"User with {user.UserID} does not exists");
            }

            await _userRepository.GetUserByIdAsync(user.UserID);
        }

        public async Task DeleteUserAsync(int id)
        {
            User DeleteUser = await _userRepository.GetUserByIdAsync(id);
            if (DeleteUser == null)
            {
                throw new NotFoundException($"User with id {id} does not exists");
            }
            await _userRepository.DeleteUserAsync(id);
        }
        public async Task<User> GetUserByEmailAsync(string email)
        {
            User user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                throw new NotFoundException($"User with email {email} does not exists");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetUsersByRoleAsync(int role)
        {
            var users = await _userRepository.GetUsersByRoleAsync(role);
            if (users == null)
            {
                throw new NotFoundException($"User with role {role} does not exists");
            }
            return users.ToList();
        }
    }
}
