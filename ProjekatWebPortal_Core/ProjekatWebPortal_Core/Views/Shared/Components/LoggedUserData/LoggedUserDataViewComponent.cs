using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Projekat.Models;
using ProjekatWebPortal_Core.Controllers;
using ProjekatWebPortal_Core.Data;
using ProjekatWebPortal_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekatWebPortal_Core.Views.Shared.Components.LoggedUserData
{
    public class LoggedUserDataViewComponent : ViewComponent
    {
        private UsersMaterijalDbContext _usersMaterijalContext;
        private readonly SignInManager<AspNetUserCustom> _signInManager;
        private readonly UserManager<AspNetUserCustom> _userManager;

        public LoggedUserDataViewComponent(UsersMaterijalDbContext umdbc,
            SignInManager<AspNetUserCustom> signInManager,
            UserManager<AspNetUserCustom> usman)
        {
            _usersMaterijalContext = umdbc;
            _signInManager = signInManager;
            _userManager = usman;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            AspNetUserCustom user = await _userManager.FindByNameAsync(this.User.Identity.Name);
            LoggedUserViewModel lu;
            if (user != null)
            {
                lu = new LoggedUserViewModel
                {
                    Username = user.UserName,
                    slika = user.Slika,
                    Role = user.Uloga
                };
                return View(lu);
            }
            //this.LogOff();

            
            return null;
        }


    }
}
