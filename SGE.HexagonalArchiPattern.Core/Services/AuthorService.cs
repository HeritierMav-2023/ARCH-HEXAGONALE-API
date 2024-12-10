using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;
using SGE.HexagonalArchiPattern.Core.Ports.Driving;


namespace SGE.HexagonalArchiPattern.Core.Services
{
    public class AuthorService : IAuthorService
    {
        //1- Propriétes Repositorie
        private readonly IAuthorRepository _authorRepository;

        //2- Constructeurs 
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }
        #region Methodes

        public async Task AddAsync(Author author)
        {
            await _authorRepository.AddAsync(author);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _authorRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetByIdAsync(Guid id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }
        #endregion
    }
}
