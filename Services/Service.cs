using FlightBookingSystem.Repositories;

namespace FlightBookingSystem.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAll();
        public async Task<T> GetByIdAsync(int id) => await _repository.GetById(id);
        public async Task AddAsync(T entity) => await _repository.Add(entity);
        public async Task UpdateAsync(T entity) => await _repository.Update(entity);
        public async Task DeleteAsync(int id) => await _repository.Delete(id);
    }
}
