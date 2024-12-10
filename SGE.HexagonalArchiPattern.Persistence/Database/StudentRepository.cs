using Microsoft.EntityFrameworkCore;
using SGE.HexagonalArchiPattern.Core.Entities;
using SGE.HexagonalArchiPattern.Core.Ports.Driven;


namespace SGE.HexagonalArchiPattern.Persistence.Database
{
    public class StudentRepository : IStudentRepository
    {
        //1- Propriétes db Context
        private readonly SgeHexagonaleDbContext _dbContext;

        //2- Constructeur 
        public StudentRepository(SgeHexagonaleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Ovveride Methods
        public async Task AddAsync(Student student)
        {
            student.CreatedOn = DateTime.UtcNow;
            await _dbContext.Students.AddAsync(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            
            var student = _dbContext.Students.FirstOrDefault(a => a.Id == id);
            if (student != null)
            {
                 student.DeletedOn = DateTime.UtcNow;
                 student.IsDeleted = true;
                 _dbContext.Attach(student);
                _dbContext.Students.Remove(student);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _dbContext.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _dbContext.Students.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task UpdateAsync(Student student)
        {
             student.ModifiedOn = DateTime.UtcNow;
            _dbContext.Students.Entry(student).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
