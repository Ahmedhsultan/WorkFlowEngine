using Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Repository
{
    public class UserRepository<T> : Irepository<T> where T : class
    {
        private readonly AppDBContext _appDBContext;

        public UserRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
    }
}
