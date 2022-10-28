using Business.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Controllers.User
{
    public class UserController : Controller
    {
        IHttpContextAccessor _httpContext;
        IUserService _userService;

        public UserController(IHttpContextAccessor httpContext, IUserService userService)
        {
            _httpContext = httpContext;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var result = _userService.GetListUser();
            if (result.Success)
            {
                var model = new UserListModel
                {
                    userListDto = result.Data
                };
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult RandomUser()
        {
            var result = _userService.GetRandomUser();
            if (result.Success)
            {
                var model = new RandomUserModel
                {
                    userListDto = result.Data
                };
                return View(model);
            }
            return View();
        }
    }
}
