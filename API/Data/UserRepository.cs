using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class UserRepository : IuserRepository
    {
        private readonly DataContext _context;
        public IMapper _Mapper { get; }

        public UserRepository(DataContext context,IMapper mapper){
            _Mapper = mapper;

              _context = context;
        }


        
        public async Task<MemberDto> GetMemberByNameAsync(string username)
        {
            return await _context.Users
            .Where(x=>x.UserName==username)
            .ProjectTo<MemberDto>(_Mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        }
          public async Task<IEnumerable<MemberDto>> GetMembersAsync()
        {
            return await _context.Users
            .ProjectTo<MemberDto>(_Mapper.ConfigurationProvider)
            .ToListAsync();
        }


        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            return await _context.Users
            .Include(p=>p.Photos)
            .ToListAsync();
        }
        
        public async Task<AppUser> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser>GetUserByName(string name)
        {
           return await _context.Users
           .Include(p=>p.Photos)
           .SingleOrDefaultAsync( x => x .UserName == name);
        }

        public async Task<bool>SaveAll()
        {
            return await _context.SaveChangesAsync()>0;
        }

        public void Update(AppUser user)
        {
            _context.Entry(user).State=EntityState.Modified;
        }



    }
}