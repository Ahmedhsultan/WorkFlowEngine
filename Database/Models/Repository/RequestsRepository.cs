#region Library
using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
#endregion

namespace Database.Models.Repository
{
    public class RequestsRepository : IRequestsRepository
    {
        #region Debendancy injection
        private readonly AppDBContext _appDBContext;
        public RequestsRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion


        public async Task<bool> addNewRequest(Requests request)
        {
            await _appDBContext.requests.AddAsync(request);
            return true;
        }

        public async Task<Requests> GetById(Guid requestId)
        {
            return await _appDBContext.requests.FindAsync(requestId);
        }

        public async Task<IEnumerable<Requests>> GetByUser(User user)
        {
            return await _appDBContext.requests.Where(x => x.user.Any(c => c.userId == user.userId)).ToListAsync();
        }

        public async Task<bool> IsExistRequest(Guid requestId)
        {
            return await _appDBContext.requests.AnyAsync(x => x.requsetId == requestId);
        }

        public async Task<bool> IsExistRequest(User user)
        {
            return await _appDBContext.requests.AnyAsync(x => x.user.Any(c => c.userId == user.userId));
        }
    }
}
