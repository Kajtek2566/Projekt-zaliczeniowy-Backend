using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface IZooUserRepository
    {
        Task AddAsync(ZooUser zooUser);
        Task DeleteAsync(string userName);
        Task UpdateAsync(ZooUser zooUser);
        Task<IEnumerable<ZooUser>> FindAllAsync();
        Task<ZooUser> FindByUserNameAsync(string userName);
    }
}
