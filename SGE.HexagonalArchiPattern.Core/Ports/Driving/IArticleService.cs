using SGE.HexagonalArchiPattern.Core.Entities;

namespace SGE.HexagonalArchiPattern.Core.Ports.Driving
{
    public interface IArticleService
    {
        Task AddAsync(Article article);

        Task<IEnumerable<Article>> GetAllAsync();

        Task<Article?> GetByIdAsync(Guid id);

        Task DeleteAsync(Guid id);
    }
}
