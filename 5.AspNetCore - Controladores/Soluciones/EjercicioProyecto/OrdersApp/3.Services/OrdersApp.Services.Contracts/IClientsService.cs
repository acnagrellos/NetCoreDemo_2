﻿using OrdersApp.Domain.Core;
using OrdersApp.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersApp.Services.Contracts
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientDto>> GetAllsAsync();
        Task<ClientDto> Get(int id);
        Task<int> Create(ClientDto client);
        Task Update(ClientDto client);
    }
}
