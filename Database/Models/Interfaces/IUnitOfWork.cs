namespace Database.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository userRepository { get; }
        public IDigramsRepository digramsRepository { get; }
        public IProcessRepository processRepository { get; }
        public IRequestsRepository requestsRepository { get; }
        public IRunningRequestsRepository runningRequestsRepository { get; }
        public ITasksRepository tasksRepository { get; }
        public IFormRepository formRepository { get; }
        public IFormVariableRepository formVariableRepository { get; }
        public ITempStorageRepository tempStorageRepository { get; }


        Task<int> Complete();
    }
}
