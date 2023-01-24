
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Extensions
{
    public static class DateTimeExtentions
    {

        public static int CalculateAge(this DateTime Dob)
        {
            var year= Dob.Year;
            var Today = DateOnly.FromDateTime(DateTime.UtcNow);
            var age = Today.Year-year;
            return age;

        }
        
    }
}