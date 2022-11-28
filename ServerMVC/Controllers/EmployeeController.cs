using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ServerMVC.Controllers
{
    public class EmployeeController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:23498/api/Employee");
        HttpClient client = new HttpClient();
        public EmployeeController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            List<Employee> modelList = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/getEmployee").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Employee>>(data);

            }
            return View(modelList);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            string data = JsonConvert.SerializeObject(employee);
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
            Employee employee = new Employee();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                employee = JsonConvert.DeserializeObject<Employee>(data);
            }
            return View("Create", employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            string data = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create", employee);
        }

        public IActionResult Delete(int id)
        {
            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                _ = response.Content.ReadAsStringAsync().Result;
            }
            return RedirectToAction("Index");
        }
    }
}
