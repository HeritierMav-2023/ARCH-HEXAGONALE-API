using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;
using SGE.HexagonalArchiPattern.Core.Ports.Driving;


namespace SGE.HexagonalArchiPattern.Core.Services
{
    public class StudentService : IStudentService
    {
        //1-Propriétes Repositorie
        private readonly IStudentRepository _studentRepository;

        //2-Constructeurs
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository; 
        }

        #region Methodes
        public async Task AddAsync(Student student)
        {
            await _studentRepository.AddAsync(student);
        }

        public async Task DeleteAsync(int id)
        {
            await _studentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
        }

        #endregion
    }
}
