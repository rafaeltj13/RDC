using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IUserAppService
    {
        Task<ICollection<UserDTO>> GetAllAsync();
        Task<UserDTO> FindAsync(int id);
        Task<UserDTO> GetByLoginAsync(string login);
        Task<UserDTO> InsertAsync(UserDTO user);
        Task<UserDTO> UpdateAsync(int id, UserDTO user);
        Task DeleteAsync(int id);
    }
}
