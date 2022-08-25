#region Library
using Database.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
#endregion


namespace Database.Models.Repository
{
    public class TasksRepository :ITasksRepository
    {
        #region Debendancy injection
        private readonly AppDBContext _appDBContext;
        public TasksRepository(AppDBContext _appDBContext)
        {
            this._appDBContext = _appDBContext;
        }
        #endregion


        public async Task<bool> addNewTask(Tasks task)
        {
            await _appDBContext.tasks.AddAsync(task);
            return true;
        }

        public async Task<Tasks> GetById(Guid taskId)
        {
            return await _appDBContext.tasks.FindAsync(taskId);
        }

        public async Task<IEnumerable<Tasks>> GetByUser(User user)
        {
            return await _appDBContext.tasks.Where(x => x.outhUser.Any(c => c.userId == user.userId)).ToListAsync();
        }

        public async Task<bool> IsExistTask(Guid taskId)
        {
            return await _appDBContext.tasks.AnyAsync(x => x.taskId == taskId);
        }

        public async Task<bool> IsExistTask(User user)
        {
            return await _appDBContext.tasks.AnyAsync(x => x.outhUser.Any(c => c.userId == user.userId));
        }

        public bool RemoveTask(Tasks task)
        {
            _appDBContext.tasks.Remove(task);
            return true;
        }
    }
}
