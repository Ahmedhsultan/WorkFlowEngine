using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface ITempStorageRepository
    {
        Task<ICollection<TempStorage>> getAll();
        void addData(TempStorage data);
        void removeALll();
    }
}
