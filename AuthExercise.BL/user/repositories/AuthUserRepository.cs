using AuthExercise.BL.user.interfaces;
using AuthExercise.BL.user.models;
using AuthExercise.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExercise.BL.user.repositories
{
    public class AuthUserRepository : IDisposable, IAuthUser
    {
        private AuthExerciseTest1Entities1 dbContext = new AuthExerciseTest1Entities1();

        public ValidationResponse RegisterUser(RegisterUserModel registerUserModel)
        {
            ValidationResponse response;
            if (CheckUserExist(registerUserModel.Email))
            {
                string message = "Oops! User exists with given email.";
                response = new ValidationResponse(false, message);
                return response;
            }
            else
            {
                DateTime date = DateTime.Now;
                // add user info
                User_Info userInfo = new User_Info();
                User newUser = new User()
                {
                    Name = registerUserModel.Name,
                    Email = registerUserModel.Email,
                    Password = registerUserModel.Password,
                    IsValidate = false,
                    Active = true,
                    Created = date,
                    User_Info = userInfo
                };
                dbContext.User.Add(newUser);
                dbContext.SaveChanges();
                string message = "Congratulations! You have registered successfully.";
                response = new ValidationResponse(true, message);
                return response;
            }            
        }

        public bool CheckUserExist(string email)
        {
            bool exist = dbContext.User.Any(u => u.Email == email);
            return exist;
        }

        public ITokenUserModel GetUserByEmailPassword(string email, string password)
        {
            User user = dbContext.User.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                ITokenUserModel responseUser = new TokenUserModel()
                {
                    ID = user.ID,
                    Name = user.Name,
                    Email = user.Email,
                    Active = user.Active,
                    IsValidate = user.IsValidate
                };
                return responseUser;
            }
            else
            {
                return null;
            }
            
            
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }


        
    }
}
