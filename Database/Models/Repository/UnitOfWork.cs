using Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Repository
{
    public class UnitOfWork :IUnitOfWork
    {
        public IUserRepository userRepository { get; private set; }
        public IDigramsRepository digramsRepository { get; private set; }
        public IProcessRepository processRepository { get; private set; }
        public IRequestsRepository requestsRepository { get; private set; }

        private readonly AppDBContext _appDBContext;

        public UnitOfWork(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;

            userRepository = new UserRepository(_appDBContext);
            digramsRepository = new DigramsRepository(_appDBContext);
            processRepository = new ProcessesRepository(_appDBContext);
            requestsRepository = new RequestsRepository(_appDBContext);
        }


        public async Task<int> Complete()
        {
            return await _appDBContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDBContext.Dispose();
        }
    }
}
