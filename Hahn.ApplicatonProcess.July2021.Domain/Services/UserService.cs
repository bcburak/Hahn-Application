using Hahn.ApplicatonProcess.July2021.Data.Interfaces;
using Hahn.ApplicatonProcess.July2021.Data.Models;
using Hahn.ApplicatonProcess.July2021.Domain.Dto;
using Mapster;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<string> CreateUser(UserDTO userDto)
        {
            try
            {
                var user = userDto.Adapt<Users>();
               

                var entity = await _unitOfWork.Users.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                if (entity != null)
                {
                    return entity.FirstName;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
           

        }

        public async Task<UserDTO> GetUser(int Id)
        {
            try
            {               

                var entity = await _unitOfWork.Users.GetByIdAsync(Id);
                await _unitOfWork.CompleteAsync();

                var dto = entity.Adapt<UserDTO>();

                if (dto != null)
                {
                    return dto;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }


        }


        public async Task<UserDTO> EditUser(int Id)
        {

            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(Id);
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.CompleteAsync();

                return user.Adapt<UserDTO>();
            }
            catch (Exception)
            {

                throw;
            }     

        }

        public async Task<string> DeleteUser(int Id)
        {

            try
            {
                var user = await _unitOfWork.Users.GetByIdAsync(Id);
                var userName = user.Adapt<UserDTO>().FirstName; // Just wanted to show different usage of mapster
                await _unitOfWork.Users.DeleteAsync(user);
                await _unitOfWork.CompleteAsync();

                return userName;


            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
