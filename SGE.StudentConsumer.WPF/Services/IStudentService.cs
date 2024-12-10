using SGE.StudentConsumer.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SGE.StudentConsumer.WPF.Services
{
    public interface IStudentService
    {
        Task DeleteTask(StudentModel studentModel);
        List<StudentModel> GetAllStudent();
        Task SaveTask(StudentModel studentModel);
        Task UpdateTask(StudentModel studentModel);
        Task<StudentModel> GetDataTask(int id);
    }
}
