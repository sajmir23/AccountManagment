using AutoMapper;
using Contracts;
using Entities;
using ServiceContracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService :IUserService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public UserService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAll(bool trackChanges)
        {
            var all=await _repository.User.GetAll(trackChanges);
            var all_map=_mapper.Map<IEnumerable<UserDto>>(all);
            return all_map;
        }
        public async Task<UserDto> GetUser(int Id, bool trackChanges)
        {
            var get=await _repository.User.GetUserById(Id, trackChanges);
            var get_map = _mapper.Map<UserDto>(get);
            return get_map;
        }
        public async Task<bool> Create(UserForCreationDto userDto)
        {
            var mapping = _mapper.Map<User>(userDto);

            _repository.User.CreateUser(mapping);

           await _repository.SaveAsync();

            return true;
        }
        public async Task<bool> Update(UserForUpdateDto userDto, int Id)
        {
            var existing = await _repository.User.GetUserById(Id, trackChanges: true);

            if (existing == null)
                throw new Exception("Nuk ekziston te jete krijuar me pare");

            _mapper.Map(userDto,existing);

            _repository.User.UpdateUser(existing);

            await _repository.SaveAsync(); 

            return true;
        }
        public async Task<bool>Delete(int Id)
        {
            var existing = await _repository.User.GetUserById(Id, trackChanges: true);

            if (existing == null)
                throw new Exception("Nuk ekziston te jete krijuar me pare");

            _repository.User.DeleteUser(existing);

            await _repository.SaveAsync();

            return true;
        }
    }
}
