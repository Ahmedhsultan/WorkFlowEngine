using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models.Repository
{
    public class FormRepository : IFormRepository
    {
        #region
        private readonly AppDBContext _appDBContext;
        public FormRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion

        public async Task<bool> addNewForm(Forms form)
        {
            await _appDBContext.forms.AddAsync(form);
            return true;
        }

        public async Task<Forms> GetById(Guid formId)
        {
            return await _appDBContext.forms.FindAsync(formId);
        }

        public async Task<IEnumerable<Forms>> GetByUser(User user)
        {
            IEnumerable<Forms> userFormsList = await _appDBContext.forms.Where(x => x.adminUsers.Any(c => c == user)).ToListAsync();
            return userFormsList;
        }

        public async Task<bool> IsExistform(Guid formId)
        {
            return await _appDBContext.forms.AnyAsync(x => x.formGuid == formId);
        }

        public async Task<bool> IsExistform(User user)
        {
            return await _appDBContext.forms.AnyAsync(x => x.adminUsers.Any(c => c == user));
        }

        public async Task<bool> Removeform(Guid formId)
        {
            Forms form = await _appDBContext.forms.FindAsync(formId);
            _appDBContext.forms.Remove(form);
            return true;
        }
    }
}
