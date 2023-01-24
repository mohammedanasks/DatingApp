using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MemberDto
    {
         public int Id { get; set; }
        public string UserName { get; set; }

        public int Age{set;get;}

        public string KnownAs { get; set; }

        public string PhotoUrl{get;set;}
        public DateTime LastActive {get;set;}

        public DateTime Created {get;set;}

        public string Gender {get;set;}

        public string Introduction {get;set;}

        public string Looking {get;set;}

        public string interests {get;set;}

        public string City {get;set;}

        public string Country {get;set;}
        
        public List<PhotoDto> Photos {get;set;}=new();
    }
}