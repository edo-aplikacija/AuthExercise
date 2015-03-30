using AuthExercise.BL.user.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExercise.BL.user.models
{
    public class TokenUserModel : ITokenUserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsValidate { get; set; }
        public bool Active { get; set; }
    }
}
