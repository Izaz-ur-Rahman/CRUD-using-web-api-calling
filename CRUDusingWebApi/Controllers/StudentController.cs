using CRUDusingWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CRUDusingWebApi.Controllers
{
    public class StudentController : Controller
    {
        private string url = "http://localhost:5030/api/StudentApi/";
        private HttpClient client = new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if(data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Student std)
        {
            string data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/Json"); // convert json into formated text
            HttpResponseMessage response = client.PostAsync(url,content).Result; // move the formated text to url to go to api for insertion
            if (response.IsSuccessStatusCode) { 
                TempData["msg"] = "Student Inserted.";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
