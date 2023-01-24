
using API.Dtos;
using API.Entities;

namespace API.interfaces
{
    public interface IuserRepository
    {

        void Update(AppUser user);

        Task<AppUser>GetUserById(int id);
        Task<AppUser>GetUserByName(string name);
        Task<IEnumerable<AppUser>>GetUsers();

        Task<MemberDto>GetMemberByNameAsync(string username);
        Task<IEnumerable<MemberDto>>GetMembersAsync();
        Task<bool>SaveAll();    
    }
}