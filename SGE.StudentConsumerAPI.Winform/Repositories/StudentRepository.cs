using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SGE.StudentConsumerAPI.Winform.Model;
using Newtonsoft.Json;

namespace SGE.StudentConsumerAPI.Winform.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        //1-Propriétes
        private readonly string URLbase;

        //2- Cnstructeurs
        public StudentRepository()
        {
            URLbase = "http://localhost:5162/api/student";
        }
        public Task DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<StudentModel> GetAllStudent()
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri("http://localhost:5162/api/");
                client.DefaultRequestHeaders.Accept.Add(
                   new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("student").Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<List<StudentModel>>().Result;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Task<StudentModel> GetDataTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StudentModel>> GetStudents()
        {
            var students = new List<StudentModel>();
            using (var httpClient = new HttpClient())
            {
                string URL = URLbase;
                var response = await httpClient.GetAsync(URL);
                var apiResponse = await response.Content.ReadAsStringAsync();

                students = JsonConvert.DeserializeObject<List<StudentModel>>(apiResponse).Select(
                        s => new StudentModel
                        {
                            Id = s.Id,
                            FirstName = s.FirstName,
                            LastName = s.LastName,
                            Email = s.Email,
                            DateOfBirth = s.DateOfBirth,

                        }
                    ).ToList();
            }
            
            return students;
        }

        public async Task SaveTask(StudentModel studentModel)
        {
            var URL = URLbase + "/Add";
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(studentModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task UpdateTask(StudentModel studentModel)
        {
            var URL = URLbase + "/Update";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(studentModel), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
    }

}
