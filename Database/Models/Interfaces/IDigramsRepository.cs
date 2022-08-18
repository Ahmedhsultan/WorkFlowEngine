using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface IDigramsRepository
    {
        Task<Digrams> GetById(Guid digramId);
        Task<bool> addNewDigram(Digrams digram);
        Task<bool> IsExistDigram(Guid digramId);
    }
}
