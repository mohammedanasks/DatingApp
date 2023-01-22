
using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Dtos;
using API.Entities;
using API.interfaces;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    public class AccountController : BaseController
    {
        public DataContext _Context { get; }
        public ITokenService _TokenService { get; }

        public AccountController(DataContext context,ITokenService tokenService){
            _TokenService = tokenService;
               _Context = context;
        } 


        [HttpPost("Register")]
        public async Task <ActionResult<UserDto>>Register(RegisterDto registerData){

            if(await UserExist(registerData.UserName))return BadRequest("User is exists");
            using var hmc= new HMACSHA512();

            var user = new AppUser()
            {
                UserName = registerData.UserName.ToLower(),
                PasswordHash=hmc.ComputeHash(Encoding.UTF8.GetBytes(registerData.Password)),
                PasswordSalt=hmc.Key
            };
            _Context.Users.Add(user);
           await _Context.SaveChangesAsync();
            return new UserDto()
            {
                UserName=user.UserName,
                Token= _TokenService.CreateToken(user)
            };

           
        } 
         
          private async Task<bool>UserExist(string username){

            return await _Context.Users.AnyAsync(x=>x.UserName==username.ToLower());
          }


          [HttpPost("login")]
          public async Task<ActionResult<UserDto>>Login(LoinDto loginDto){

            var user = await _Context.Users.SingleOrDefaultAsync(x=>x.UserName==loginDto.UserName);

            if(user==null)return Unauthorized("user not found");

            using var hmac= new HMACSHA512(user.PasswordSalt);
           var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

           for(int i=0; i<
           ComputedHash.Length;i++){
               
               if(ComputedHash[i]!=user.PasswordHash[i])return Unauthorized("Invalid Password");
           }
           return new UserDto{
            UserName=user.UserName,
            Token=_TokenService.CreateToken(user)
           };



          }
    }
}