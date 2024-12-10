using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;
using SGE.HexagonalArchiPattern.Core.Ports.Driving;


namespace SGE.HexagonalArchiPattern.Core.Services
{
    public class ArticleService : IArticleService
    {
        //1- Propriétes Repository
        private readonly IArticleRepository _articleRepository;

        //2- Constructeurs
        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        #region Methodes

        public async Task AddAsync(Article article)
        {
            await _articleRepository.AddAsync(article);
        }

        public async Task DeleteAsync(Guid id)
        {
           await _articleRepository.DeleteAsync(id); 
        }

        public async Task<IEnumerable<Article>> GetAllAsync()
        {
            return await _articleRepository.GetAllAsync();
        }

        public async Task<Article?> GetByIdAsync(Guid id)
        {
            return await _articleRepository.GetByIdAsync(id);
        }
        #endregion
    }
}
