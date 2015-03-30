using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExercise.BL.user.interfaces
{
    public interface ITokenUserModel
    {
        int ID { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        bool IsValidate { get; set; }
        bool Active { get; set; }
    }
}
