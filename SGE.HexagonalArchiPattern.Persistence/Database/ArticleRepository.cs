using Microsoft.EntityFrameworkCore;
using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;


namespace SGE.HexagonalArchiPattern.Persistence.Database
{
    public class ArticleRepository : IArticleRepository
    {
        //1-Propriétes Db context
        private readonly SgeHexagonaleDbContext _dbContext;

        //2- Constructeur
        public ArticleRepository(SgeHexagonaleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Ovveride Methods
        public async Task AddAsync(Article article)
        {
            await _dbContext.Articles.AddAsync(article);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var article = _dbContext.Articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
            {
                _dbContext.Articles.Remove(article);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _dbContext.Articles.AsNoTracking().ToListAsync();
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Articles.FirstOrDefaultAsync(a =>a.Id == id);
        }

        public async Task UpdateAsync(Article article)
        {
            _dbContext.Articles.Entry(article).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
