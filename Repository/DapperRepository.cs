using Contracts;
using Dapper;
using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DapperRepository : IDapperRepository
    {
        private readonly DapperContext _context;
        public DapperRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BankAccountsDto>> GetAll()
        {
            var query = "SELECT * FROM BankAccounts";

            using (var connection = _context.CreateConnection())
            {
                var result = await connection.QueryAsync<BankAccountsDto>(query);
                return result;
            }
        }
    }
}
