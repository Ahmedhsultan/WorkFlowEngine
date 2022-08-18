#region Library
using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace Database.Models.Repository
{
    public class UserRepository : IUserRepository
    {
        #region Debendancy injection
        private readonly AppDBContext _appDBContext;
        public UserRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion

        public async Task<bool> addNewUser(User user)
        {
            await _appDBContext.user.AddAsync(user);
            return true;
        }

        public async Task<IEnumerable<User>> findAll()
        {
            return await _appDBContext.user.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            try
            {
                return await _appDBContext.user.FindAsync(id);
            }
            catch
            {
                return null;
            }
        }

        public async Task<User> GetByUserName(string userName)
        {
            if (await ExistUserName(userName))
            {
                User user = await _appDBContext.user.SingleOrDefaultAsync(x => x.userName == userName);
                //.Include(m => m.messages)
                return user;
            }
            return null;
        }

        public async Task<bool> ExistUserName(string userName)
        {
            return await _appDBContext.user.AnyAsync(x => x.userName == userName);
        }
    }
}
