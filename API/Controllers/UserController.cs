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
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly DataContext _Context ; 
        public UserController(DataContext context){

            _Context = context;
        }

        [AllowAnonymous]
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