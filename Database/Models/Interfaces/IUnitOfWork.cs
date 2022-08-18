namespace Database.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository userRepository { get; }
        public IDigramsRepository digramsRepository { get; }
        public IProcessRepository processRepository { get; }
        public IRequestsRepository requestsRepository { get; }


        Task<int> Complete();
    }
}
