using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface IProcessRepository
    {
        Task<Processes> GetById(Guid processId);
        Task<bool> addNewProcess(Processes process);
        Task<bool> IsExistProcess(Guid processId);
    }
}
