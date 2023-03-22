using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Models;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {       
         UserRepository uh = new UserRepository();

        [HttpGet]
         public t_user Get(int id)
        {
            return uh.GetProfile(id);
        }

        [HttpPost]
        [Route("Register")]
        // POST: api/UserApi
        public IActionResult Register([FromBody]t_user data)
        {
            return Ok(uh.Register(data));
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(vm_login data){
            return Ok(uh.Login(data));
        }
        [HttpPut]
        // PUT: api/UserApi/5
        public IActionResult Put([FromBody]t_user data)
        {
            return Ok(uh.ChangeProfile(data));
        }

        [HttpDelete]
        // DELETE: api/UserApi/5
        public IActionResult Delete(int id)
        {   
            return Ok(uh.DeleteProfile(id));
        }
    }
}