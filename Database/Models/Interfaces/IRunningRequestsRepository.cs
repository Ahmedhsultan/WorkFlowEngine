using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface IRunningRequestsRepository
    {
        Task<RunningRequests> GetById(Guid runningRequestId);
        Task<IEnumerable<RunningRequests>> GetByUser(User user);
        Task<bool> addNewRunningRequests(RunningRequests runningRequests);
        Task<bool> IsExistRunningRequests(Guid runningRequestId);
        Task<bool> IsExistRunningRequests(User user);
    }
}
