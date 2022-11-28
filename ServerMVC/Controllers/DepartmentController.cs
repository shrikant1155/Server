using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServerMVC.Controllers
{
    public class DepartmentController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:23498/api/Department");
        HttpClient client = new HttpClient();
        public DepartmentController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Department> modelList = new List<Department>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/getDepartment").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Department>>(data);

            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            string data = JsonConvert.SerializeObject(department);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Department department = new Department();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                department = JsonConvert.DeserializeObject<Department>(data);
            }
            return View("Create", department);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            string data = JsonConvert.SerializeObject(department);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", department);
        }

        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                _ = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
    }
}
