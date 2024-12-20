﻿using SGE.HexagonalArchiPattern.Core.Entities;

namespace SGE.HexagonalArchiPattern.Core.Ports.Driven
{
    public interface IArticleRepository
    {
        Task AddAsync(Article article);

        Task<IEnumerable<Article>> GetAllAsync();

        Task<Article?> GetByIdAsync(Guid id);

        Task UpdateAsync(Article article);

        Task DeleteAsync(Guid id);
    }
}
