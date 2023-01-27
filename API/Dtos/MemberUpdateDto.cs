using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MemberUpdateDto
    {
        public string Introduction { get; set; }

        public string Looking { get; set; }
        public string interests { get; set; }

        public string Country{get;set;}

        public string City{get;set;}
    }
}