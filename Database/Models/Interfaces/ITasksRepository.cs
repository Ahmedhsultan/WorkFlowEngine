using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface ITasksRepository
    {
        Task<Tasks> GetById(Guid taskId);
        Task<IEnumerable<Tasks>> GetByUser(User user);
        Task<bool> addNewTask(Tasks task);
        Task<bool> IsExistTask(Guid taskId);
        Task<bool> IsExistTask(User user);
        bool RemoveTask(Tasks task);
    }
}
