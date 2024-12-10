using Newtonsoft.Json;
using SGE.StudentConsumer.WPF.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace SGE.StudentConsumer.WPF.Services
{
    public class StudentService : IStudentService
    {
        private readonly string URLbase;
        #region Constructeurs
        public StudentService()
        {
            URLbase = "http://localhost:5162/api/student";
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        public async Task DeleteTask(int id)
        {
            string URL = URLbase + "/Delete/"+ id;

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StudentModel> GetDataTask(int id)
        {
            string URL = URLbase + $"/GetById?id={id}";
            var student = new StudentModel();

            using (var httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(URL);
                string apiResponse = await response.Content.ReadAsStringAsync();
                student = JsonConvert.DeserializeObject<StudentModel>(apiResponse);
            }
            return student;
        }

        public async Task SaveTask(StudentModel studentModel)
        {
            string URL = URLbase + "/Add";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(studentModel), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }

        public async Task UpdateTask(StudentModel studentModel)
        {
            string URL = URLbase + "/Update";

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(studentModel), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(URL, content);
                string apiResponse = await response.Content.ReadAsStringAsync();
            }
        }
        #endregion
    }
}
