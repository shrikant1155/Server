using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Models;
using System;
using System.Net.Http;
using System.Text;

namespace ServerMVC.Controllers
{
    public class SecurityController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:23498/api/Account");
        HttpClient client = new HttpClient();
        public SecurityController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Server.Models.LoginViewModel model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/login", content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(AdminUser model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/register", content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Security");
            }
            return RedirectToAction("Register", "Security");
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Security");
        }
    }
}
