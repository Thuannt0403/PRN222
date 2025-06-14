using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using BusinessObjects;
using Services;
using ProductManagementMVC.Models; // 👈 Import ViewModel

namespace ProductManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = _accountService.GetAccountByEmail(model.EmailAddress.Trim());

                if (user == null)
                {
                    Console.WriteLine($"User with email {model.EmailAddress} not found.");
                    ModelState.AddModelError("", "User không tồn tại");
                }
                else
                {
                    Console.WriteLine($"User found: {user.MemberId}, Password in DB: '{user.MemberPassword}'");
                    Console.WriteLine($"Password entered: '{model.MemberPassword}'");

                    if (user.MemberPassword.Trim() == model.MemberPassword.Trim())
                    {
                        HttpContext.Session.SetString("UserId", user.MemberId);
                        HttpContext.Session.SetString("Username", user.FullName);

                        return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                        Console.WriteLine("Password does not match.");
                        ModelState.AddModelError("", "Invalid username or password.");
                    }
                }
            }

            return View(model);
        }
    }

    }
