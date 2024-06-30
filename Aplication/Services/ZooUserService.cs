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

        public async Task Add(ZooUserDTO zooUserDTO)
        {
            var zooUser = _mapper.Map<ZooUser>(zooUserDTO);
            await _zooUserRepository.AddAsync(zooUser);
        }

        public async Task Delete(string userName)
        {
            await _zooUserRepository.DeleteAsync(userName);
        }

        public async Task<IEnumerable<ZooUserDTO>> FindAll()
        {
            var zooUsers = await _zooUserRepository.FindAllAsync();
            return _mapper.Map<IEnumerable<ZooUserDTO>>(zooUsers);
        }

        public async Task<ZooUserDTO> FindByUserName(string userName)
        {
            var zooUser = await _zooUserRepository.FindByUserNameAsync(userName);
            return _mapper.Map<ZooUserDTO>(zooUser);
        }

        public Task RegisterUserAsync(RegisterDTO registerDTO)
        {
            throw new NotImplementedException();
        }

        public async Task Update(ZooUserDTO zooUserDTO)
        {
            var zooUser = _mapper.Map<ZooUser>(zooUserDTO);
            await _zooUserRepository.UpdateAsync(zooUser);
        }
    }
}
