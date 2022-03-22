using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DataAccessLayer.ViewModel;

namespace Client.Controllers
{
    public class MultiplexController : Controller
    {
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/");

            HttpResponseMessage respone = client.GetAsync("api/Multiplex").Result;
            if (respone.IsSuccessStatusCode)
            {
                var jsonData = respone.Content.ReadAsStringAsync().Result;
                List<Multiplex> Records = JsonConvert.DeserializeObject<List<Multiplex>>(jsonData);
                return View(Records);
            }

            //Error Occur Set View Bag
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(MultiplexRegisterViewModel obj)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/");

            try
            {
                HttpResponseMessage responseMessage = client.PostAsJsonAsync<MultiplexRegisterViewModel>("api/Multiplex", obj).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return ;
                }
            }
            catch (Exception)
            {
                throw new Exception("Api Calling Failed");
            }
            return;
        }
    }
}
