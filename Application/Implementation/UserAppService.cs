using Application.DTO;
using Application.Interface;
using Domain.Interface;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userService;

        public UserAppService(IUserDomainService userService)
        {
            _userService = userService;
        }

        public async Task<ICollection<UserDTO>> GetAllAsync()
        {
            var result = await _userService.GetAllAsync();
            return AutoMapper.Mapper.Map<ICollection<UserDTO>>(result);
        }

        public async Task<UserDTO> FindAsync(int id)
        {
            var result = await _userService.FindAsync(id);
            return AutoMapper.Mapper.Map<UserDTO>(result);
        }

        public async Task<UserDTO> InsertAsync(UserDTO user)
        {
            var result = await _userService.InsertAsync(AutoMapper.Mapper.Map<User>(user));
            return AutoMapper.Mapper.Map<UserDTO>(result);
        }

        public async Task<UserDTO> UpdateAsync(int id, UserDTO user)
        {
            var result = await _userService.UpdateAsync(AutoMapper.Mapper.Map<User>(user), id);
            return AutoMapper.Mapper.Map<UserDTO>(result);
        }

        public async Task DeleteAsync(int id)
        {
            await _userService.DeleteAsync(id);
        }
    }
}
