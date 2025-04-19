﻿using Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDapperRepository
    {
        Task<IEnumerable<BankAccountsDto>> GetAll();
    }
}
