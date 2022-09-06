#region Library
using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Database.Models.Repository
{
    public class RunningRequestsRepository : IRunningRequestsRepository
    {
        #region Debendancy injection
        private readonly AppDBContext _appDBContext;
        public RunningRequestsRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion


        public async Task<bool> addNewRunningRequests(RunningRequests runningRequests)
        {
            await _appDBContext.runningRequests.AddAsync(runningRequests);
            return true;
        }

        public async  Task<RunningRequests> GetById(Guid runningRequestId)
        {
            return await _appDBContext.runningRequests.FindAsync(runningRequestId);
        }

        public async Task<IEnumerable<RunningRequests>> GetByUser(User user)
        {
            return await _appDBContext.runningRequests.Where(x => x.assigneeUser.userId == user.userId).ToListAsync();
        }

        public async Task<bool> IsExistRunningRequests(Guid runningRequestId)
        {
            return await _appDBContext.runningRequests.AnyAsync(x => x.runningRequeststId == runningRequestId);
        }

        public async Task<bool> IsExistRunningRequests(User user)
        {
            return await _appDBContext.runningRequests.AnyAsync(x => x.assigneeUser.userId == user.userId);
        }
    }
}
