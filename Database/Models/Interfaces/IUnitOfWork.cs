namespace Database.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository userRepository { get; }
        public IDigramsRepository digramsRepository { get; }
        public IProcessRepository processRepository { get; }
        public IRequestsRepository requestsRepository { get; }
        public ITasksRepository tasksRepository { get; }


        Task<int> Complete();
    }
}
