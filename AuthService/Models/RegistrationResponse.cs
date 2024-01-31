using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class RegistrationResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public int? UserId { get; set; }

    }
}
