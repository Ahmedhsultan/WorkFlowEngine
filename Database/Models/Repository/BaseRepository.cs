using Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Repository
{
    public class BaseRepository<T> : Irepository<T> where T : class
    {
        private readonly AppDBContext _appDBContext;

        public BaseRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
    }
}
