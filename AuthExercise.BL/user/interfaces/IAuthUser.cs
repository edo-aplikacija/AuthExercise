using AuthExercise.BL.user.models;
using AuthExercise.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExercise.BL.user.interfaces
{
    public interface IAuthUser
    {
        ValidationResponse RegisterUser(RegisterUserModel registerUserModel);
        bool CheckUserExist(string email);
        ITokenUserModel GetUserByEmailPassword(string email, string password);
    }
}
