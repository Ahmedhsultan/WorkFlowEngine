#region Library
using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Database.Models.Repository
{
    public class ProcessesRepository : IProcessRepository
    {
        #region Debendance Injection
        private readonly AppDBContext _appDBContext;
        public ProcessesRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion

        public async Task<bool> addNewProcess(Processes process)
        {
            await _appDBContext.processes.AddAsync(process);
            return true;
        }

        public async Task<bool> IsExistProcess(Guid processId)
        {
            return await _appDBContext.processes.AnyAsync(x => x.Id == processId);
        }

        public async Task<Processes> GetById(Guid processId)
        {
            return await _appDBContext.processes.FindAsync(processId);
        }
    }
}
