using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using API.ViewModel;

namespace MVCApp.Controllers
{
    public class AccountController : Controller
    {
        HttpClient HttpClient;
        string address;
        public AccountController()
        {
            this.address = "https://localhost:44321/api/Account";
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var result = HttpClient.PostAsync(address, content).Result;
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponClient>(await result.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
