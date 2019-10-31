﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Identity;
using MindOverMatter.Models.User;

namespace MindOverMatter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(bool isInvalid = false)
        {

            return View(isInvalid);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            // var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            // authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult RegisterNewUser(User user)
        {
            var userStore = new UserStore<ApplicationUser>(new ProfileContext());
            var manager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser() { UserName = user.Username, FirstName = user.FirstName, LastName = user.LastName, Password = user.Password, Email = user.Email };
            IdentityResult result = manager.Create(user, Password.Text);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            // var userStore = new UserStore<ApplicationUser>(new ProfileContext());
            // var userManager = new UserManager<ApplicationUser>(userStore);
            //var attemptedUser = userManager.Find(user.Username, user.Password);
            if(user.Username != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return Login();
            }
            
        }
    }
}