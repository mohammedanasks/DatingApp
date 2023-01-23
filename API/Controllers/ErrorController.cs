

using API.Data;
using API.Dtos;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController:BaseController
    {
       
        public DataContext _Context { get; }
        public ErrorController(DataContext context){
                    _Context = context;
        }
    

        
        [HttpGet("auth")]
        public ActionResult<string>GetSecret(){
            return Unauthorized();
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser>GetNotFound(){
            
            var data = _Context.Users.Find(-1);
            if(data==null) return NotFound();
            return data;
        }

        [HttpGet("server-error")]
        public ActionResult<string>GetServerError(){
            var  data = _Context.Users.Find(-1);
           var returnData = data.ToString();
           return returnData;

        }

        [HttpGet("bad-request")]
        public ActionResult<string>GetBadRequest(){

            return BadRequest("this is a bad request");
        }
    }
}