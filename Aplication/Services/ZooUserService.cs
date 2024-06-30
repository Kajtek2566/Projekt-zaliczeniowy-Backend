using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.DTO;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ZooUserService : IZooUserService
    {
        private readonly IZooUserRepository _zooUserRepository;
        private readonly IMapper _mapper;

        public ZooUserService(IZooUserRepository zooUserRepository, IMapper mapper)
        {
            _zooUserRepository = zooUserRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ZooUserDTO>> GetAllUsersAsync()
        {
            var users = await _zooUserRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<ZooUserDTO>>(users);
        }

        public async Task<ZooUserDTO> GetUserByIdAsync(int id)
        {
            var user = await _zooUserRepository.GetUserByIdAsync(id);
            return _mapper.Map<ZooUserDTO>(user);
        }

        public async Task<ZooUser> GetUserByLoginAsync(string login)
        {
            return await _zooUserRepository.GetUserByLoginAsync(login);
        }

        public async Task AddUserAsync(ZooUser zooUser)
        {
            zooUser.Password = BCrypt.Net.BCrypt.HashPassword(zooUser.Password);
            await _zooUserRepository.AddUserAsync(zooUser);
        }

        public async Task UpdateUserAsync(ZooUserDTO zooUserDTO)
        {
            var existingUser = await _zooUserRepository.GetUserByIdAsync(zooUserDTO.ID);

            if (existingUser == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Copy only editable fields, leave the password unchanged
            existingUser.Login = zooUserDTO.Login;
            existingUser.FirstName = zooUserDTO.FirstName;
            existingUser.LastName = zooUserDTO.LastName;
            existingUser.Email = zooUserDTO.Email;
            existingUser.PhoneNumber = zooUserDTO.PhoneNumber;
            existingUser.Role = zooUserDTO.Role;

            await _zooUserRepository.UpdateUserAsync(existingUser);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _zooUserRepository.DeleteUserAsync(id);
        }

        public async Task RegisterUserAsync(RegisterDTO registerDTO)
        {
            var user = new ZooUser
            {
                Login = registerDTO.Login,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                Role = "User"
            };

            await _zooUserRepository.AddUserAsync(user);
        }
    }
}
