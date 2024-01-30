using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class RegistrationRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public string NationalId { get; set; }

        public string Password { get; set; }

        public string Salt { get; set; }

        public string Role { get; set; }
    }
}
