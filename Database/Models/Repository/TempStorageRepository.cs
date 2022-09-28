using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Repository
{
    public class TempStorageRepository : ITempStorageRepository
    {
        #region Debendency injection
        public AppDBContext appDBContext { get; }
        public TempStorageRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        #endregion

        public async Task<ICollection<TempStorage>> getAll()
        {
            return await appDBContext.tempStorage.ToListAsync();
        }

        public void removeALll()
        {
            appDBContext.tempStorage.RemoveRange(appDBContext.tempStorage);
        }

        public async void addData(TempStorage tempStorage)
        {
            await appDBContext.tempStorage.AddAsync(tempStorage);
        }
    }
}
