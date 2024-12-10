using SGE.HexagonalArchiPattern.Core.Entities;

namespace SGE.HexagonalArchiPattern.Core.Ports.Driving
{
    public interface IStudentService
    {
        Task AddAsync(Student student);

        Task<IEnumerable<Student>> GetAllAsync();

        Task<Student?> GetByIdAsync(int id);

        Task UpdateAsync(Student student);

        Task DeleteAsync(int id);
    }
}
