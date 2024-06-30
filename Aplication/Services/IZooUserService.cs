using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IZooUserService
    {
        Task Add(ZooUserDTO zooUserDTO);
        Task Delete(string userName);
        Task Update(ZooUserDTO zooUserDTO);
        Task<IEnumerable<ZooUserDTO>> FindAll();
        Task<ZooUserDTO> FindByUserName(string userName);

        Task RegisterUserAsync(RegisterDTO registerDTO);
    }
}
