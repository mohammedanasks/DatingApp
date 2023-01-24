
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using API.interfaces;
using API.AutoMapper;
using AutoMapper;
using API.Dtos;

namespace API.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly IuserRepository _UserRepository;
        private readonly IMapper _Mapper;
        public UserController(IuserRepository UserRepository,IMapper mapper){
              _Mapper = mapper;
              _UserRepository = UserRepository;
        }
          

        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<MemberDto>>>GetUsers(){

        //     var users = await _UserRepository.GetUsers();
        //     var ReturnData = _Mapper.Map<IEnumerable<MemberDto>>(users);
        //    return Ok(ReturnData);
        // }

        // [HttpGet("{username}")]
        // public async Task<ActionResult<MemberDto>>GetUser(string username){

        //     var user = await _UserRepository.GetUserByName(username);
        //     return _Mapper.Map<MemberDto>(user);
        // }


        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>>Getmember(string username){

            return await _UserRepository.GetMemberByNameAsync(username);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>>GetMembers(){
            var users= await _UserRepository.GetMembersAsync();
            return Ok(users);
        }
           

    }
}