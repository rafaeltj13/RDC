using Domain.Interface;
using Entities;
using Infrastructure.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Implementation
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<User>> GetAllAsync()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> FindAsync(int id)
        {
            return await _unitOfWork.UserRepository.FindAsync(id);
        }

        public async Task<User> InsertAsync(User entity)
        {
            await _unitOfWork.UserRepository.InsertAsync(entity);

            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task<User> UpdateAsync(User entity, object key)
        {
            await _unitOfWork.UserRepository.UpdateAsync(entity, key);

            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task DeleteAsync(object key)
        {
            await _unitOfWork.UserRepository.DeleteAsync(key);

            await _unitOfWork.SaveAsync();
        }
    }
}
