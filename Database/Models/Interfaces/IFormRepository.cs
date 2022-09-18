using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface IFormRepository
    {
        Task<Forms> GetById(Guid formId);
        Task<bool> addNewForm(Forms form);
        Task<bool> IsExistform(Guid formId);
        Task<bool> Removeform(Guid formId);
        Task<bool> IsExistform(User user);
        Task<IEnumerable<Forms>> GetByUser(User user);
    }
}
