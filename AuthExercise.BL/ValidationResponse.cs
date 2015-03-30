using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthExercise.BL
{
    public class ValidationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ValidationResponse(bool success, string message)
        {
            this.Success = success;
            this.Message = message;
        }
    }
}
