using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(Guid id);
        Task<IEnumerable<User>> findAll();
        Task<User> GetByUserName(string userName);
        Task<bool> addNewUser(User user);
        Task<bool> ExistUserName(string userName);
    }
}
