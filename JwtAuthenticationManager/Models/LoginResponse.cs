using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class LoginResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string JwtToken { get; set; }

        public int ExpiresIn { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }

    }
}
