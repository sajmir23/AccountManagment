using AutoMapper;
using Contracts;
using Entities;
using Microsoft.AspNetCore.Http;
using ServiceContracts;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ClientsService : IClientsService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public ClientsService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ClientforUpdateDto>> GetAll(bool trackChanges)
        {
            var client = await _repository.Clients.GetAllClients(trackChanges);
            var client_dto=_mapper.Map<IEnumerable<ClientforUpdateDto>>(client); 
            return client_dto;
        }
        public async Task<ClientforUpdateDto> GetClient(int Id,bool trackChanges)
        {
            var client =  await _repository.Clients.GetClient(Id,trackChanges);
            var cleintdto = _mapper.Map<ClientforUpdateDto>(client);
            return cleintdto;
        }
        public async Task<bool> Create(ClientForCreationDto clientForCreationDto)
        {
            try
            {
               var client = _mapper.Map<Clients>(clientForCreationDto);

               client.DateCreated= DateTime.Now;

               _repository.Clients.CreateClient(client);

               await  _repository.SaveAsync();

               return true;
            }
            catch(Exception ex) 
            {
                _logger.LogWarning($"Gabim gjatë krijimit të klientit: {ex.Message}");
                throw ;
            }
        }
        public async Task<bool> Update(ClientForUpdateDto clientDto, int Id)
        {
            var client = await _repository.Clients.GetClient(Id, trackChanges:false);

            _mapper.Map(client, clientDto);

            client.DateUpdated= DateTime.Now;

            _repository.Clients.UpdateClient(client);

            await _repository.SaveAsync();

            return true;
        }
        public async Task<bool> Delete(int Id)
        {
            var client = await _repository.Clients.GetClient(Id,trackChanges:false);

            _repository.Clients.DeleteClient(client);

            await _repository.SaveAsync();

            return true;
        }
    }
}
