using ApplicationCore.Entities;
using ApplicationCore.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [ActionName("Login")]
        public HttpResponseMessage Post(User user)
        {

            if (ModelState.IsValid && user != null)
            {

                user = _userService.GetUserByName(user.IdUser, user.Password);

                if(user != null)
                {
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;                   
                }
                else
                {
                    var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                    {
                        Content = new StringContent("NON TROVATO")
                    };
                    return response;
                }
                
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            //return _userService.GetUserByName(user.IdUser, user.Password);
        }
    }
}
