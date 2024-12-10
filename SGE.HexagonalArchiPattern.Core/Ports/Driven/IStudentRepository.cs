using SGE.HexagonalArchiPattern.Core.Entities;

namespace SGE.HexagonalArchiPattern.Core.Ports.Driven
{
    public interface IStudentRepository
    {
        Task AddAsync(Student student);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int id);
    }
}
