using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAll(bool trackChanges);
        Task<UserDto> GetUser(int Id,bool trackChanges);
        Task<bool>Create(UserForCreationDto userDto);
        Task<bool>Update(UserForUpdateDto userDto,int Id);
        Task<bool>Delete(int Id);
    }
}
