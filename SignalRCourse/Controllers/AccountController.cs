using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using SignalRCourse.Model;
using SignalRCourse.Repository;

namespace SignalRCourse.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Index() 
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        
        public async Task<IActionResult> Signout()
        {
            var result = await _accountRepository.SignOutAsync();

            if (!result)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public async Task<IActionResult> Register(RegisterAccountDto register) 
        {
            var result = await _accountRepository.RegisterAccount(register);
            if (!result)
            {
                return RedirectToAction("Register", register);
            }
            return RedirectToAction("Index");
        }

        [HttpPost()]
        public async Task<IActionResult> Login(LoginAccountDto loginDto)
        {
            var result = await _accountRepository.LoginAccount(loginDto);
            if (!result)
            {
                return RedirectToAction("Login", loginDto);
            }
            return RedirectToAction("Index");
        } 
    }
}
