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
    public class DigramsRepository :IDigramsRepository
    {
        #region Debendancy injection
        private readonly AppDBContext _appDBContext;
        public DigramsRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion

        public async Task<bool> addNewDigram(Digrams digram)
        {
            await _appDBContext.digrams.AddAsync(digram);
            return true;
        }

        public async Task<bool> IsExistDigram(Guid digramId)
        {
            return await _appDBContext.digrams.AnyAsync(x => x.digramId == digramId);
        }

        public async Task<Digrams> GetById(Guid digramId)
        {
            return await _appDBContext.digrams.FindAsync(digramId);
        }

        public async Task<bool> RemoveDigrame(Guid digramId)
        {
            Digrams digram = await _appDBContext.digrams.FindAsync(digramId);
            _appDBContext.digrams.Remove(digram);
            return true;
        }
    }
}
