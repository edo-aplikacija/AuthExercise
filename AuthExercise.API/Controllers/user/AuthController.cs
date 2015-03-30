using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AuthExercise.BL.user.interfaces;
using AuthExercise.BL.user.repositories;
using AuthExercise.BL.user.models;
using AuthExercise.BL;

namespace AuthExercise.API.Controllers.user
{
    public class AuthController : ApiController
    {
        private IAuthUser _repo = new AuthUserRepository();
 
        [Route("api/signup")]
        public IHttpActionResult Post(RegisterUserModel model)
        {
            if (model == null)
            {
                string message = "Oops! Form is not valid.";
                return BadRequest(message);
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                ValidationResponse response = _repo.RegisterUser(model);
                if (response.Success)
                {
                    return Ok(response.Message);
                }
                else
                {
                    return BadRequest(response.Message);
                }
                
            }
        }
    }
}