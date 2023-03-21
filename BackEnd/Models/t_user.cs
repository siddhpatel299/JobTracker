using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class t_user
    {
        
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public long Contact { get; set; }

        public string Image { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string Degree { get; set; }
    }
}