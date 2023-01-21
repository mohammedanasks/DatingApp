using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _Context ; 
        public UserController(DataContext context){

            _Context = context;
        }


        [HttpGet]
        public async Task<ActionResult <IEnumerable<AppUser>>>GetUsers(){

            var users= await _Context.Users.ToListAsync();

           return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>>GetUser(int id){
            return await _Context.Users.FindAsync(id);
        }

           

    }
}