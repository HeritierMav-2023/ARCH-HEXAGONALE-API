using Microsoft.EntityFrameworkCore;
using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;


namespace SGE.HexagonalArchiPattern.Persistence.Database
{
    public class AuthorRepository : IAuthorRepository
    {
        //1-Propriétes Db Context
        private readonly SgeHexagonaleDbContext _dbContext;

        //2- Constructeur
        public AuthorRepository(SgeHexagonaleDbContext dbContext)
        {
            _dbContext = dbContext; 
        }

        #region Ovveride Methods
        public async Task AddAsync(Author author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _dbContext.Authors.AsNoTracking().ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        #endregion
    }
}
