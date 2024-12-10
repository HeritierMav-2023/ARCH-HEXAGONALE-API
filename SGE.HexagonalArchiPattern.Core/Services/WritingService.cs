using SGE.HexagonalArchiPattern.Core.Enums;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;
using SGE.HexagonalArchiPattern.Core.Ports.Driving;


namespace SGE.HexagonalArchiPattern.Core.Services
{
    public class WritingService : IWritingService
    {
        //1- Propriétes Repositorie
        private readonly IAuthorRepository _authorRepository;
        private readonly IArticleRepository _articleRepository;

        //2- Constructeurs
        public WritingService(IAuthorRepository authorRepository, IArticleRepository articleRepository)
        {
            _authorRepository = authorRepository;
            _articleRepository = articleRepository;
        }

        #region Methodes
        public async Task ChangeArticleStatusAsync(Guid articleId, WritingStatus writingStatus)
        {
            var article = await _articleRepository.GetByIdAsync(articleId);
            if (article == null)
            {
                return;
            }

            article.WritingStatus = writingStatus;
            await _articleRepository.UpdateAsync(article);
        }

        public async Task StartWritingAsync(Guid authorId, Guid articleId)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            if (author == null)
            {
                return;
            }

            var article = await _articleRepository.GetByIdAsync(articleId);
            if (article == null)
            {
                return;
            }

            article.AuthorId = author.Id;
            await _articleRepository.UpdateAsync(article);

        }
        #endregion
    }
}