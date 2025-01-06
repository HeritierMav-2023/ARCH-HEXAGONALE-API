using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGE.StudentConsumerAPI.Winform.Model
{
    public interface IStudentRepository
    {
        Task SaveTask(StudentModel studentModel);
        Task DeleteTask(int id);
        List<StudentModel> GetAllStudent();

        Task<List<StudentModel>> GetStudents();
        Task UpdateTask(StudentModel studentModel);
        Task<StudentModel> GetDataTask(int id);
    }
}
