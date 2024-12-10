using SGE.HexagonalArchiPattern.Core.Entities;

namespace SGE.HexagonalArchiPattern.Core.Ports.Driving
{
    public interface IAuthorService
    {
        Task AddAsync(Author author);

        Task<IEnumerable<Author>> GetAllAsync();

        Task<Author?> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
