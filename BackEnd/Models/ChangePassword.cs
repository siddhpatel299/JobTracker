using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ChangePassword
    {
        public int OldPassword{get; set;}
        public int NewPassword {get; set;}

        public int ConfirmPassword {get; set;}
    }
}