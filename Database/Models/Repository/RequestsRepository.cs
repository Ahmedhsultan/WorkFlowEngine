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

        public async Task<bool> IsExistRequest(Guid requestId)
        {
            return await _appDBContext.requests.AnyAsync(x => x.requsetId == requestId);
        }
    }
}
