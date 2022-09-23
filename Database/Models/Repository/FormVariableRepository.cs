using Database.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Repository
{
    public class FormVariableRepository :IFormVariableRepository
    {
        #region
        private readonly AppDBContext _appDBContext;
        public FormVariableRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion
    }
}
