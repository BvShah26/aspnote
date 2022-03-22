using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DataAccessLayer.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Client.Controllers
{

    public class MultiplexController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<MultiplexController> _logger;

        public MultiplexController(SignInManager<ApplicationUser> signInManager,ILogger<MultiplexController> logger,UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Authorize(Roles = "MultiplexAdmin")]
        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44345/");

            HttpResponseMessage respone = client.GetAsync("api/Multiplex").Result;
            if (respone.IsSuccessStatusCode)
            {
                var jsonData = respone.Content.ReadAsStringAsync().Result;
                List<Multiplex> Records = JsonConvert.DeserializeObject<List<Multiplex>>(jsonData);
                ViewBag.Name = @HttpContext.Session.GetString("Admin");
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
                    return;
                }
            }
            catch (Exception)
            {
                throw new Exception("Api Calling Failed");
            }
            return;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel Input)
        {

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, true, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("Admin", "Session Data");
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index");
                }
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return Page();
                //}
            }
            return View();
        }
    }
}
