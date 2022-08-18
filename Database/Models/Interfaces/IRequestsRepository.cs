﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface IRequestsRepository
    {
        Task<Requests> GetById(Guid recuestId);
        Task<bool> addNewRequest(Requests request);
        Task<bool> IsExistRequest(Guid recuestId);
    }
}