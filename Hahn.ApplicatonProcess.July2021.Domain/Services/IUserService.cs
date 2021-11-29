using Hahn.ApplicatonProcess.July2021.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Domain.Services
{
    public interface IUserService
    {

        Task<string> CreateUser(UserDTO userDto);
        Task<UserDTO> GetUser(int Id);
        Task<UserDTO> EditUser(int Id);
        Task<string> DeleteUser(int Id);
    }
}
