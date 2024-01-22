using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Models
{
    public class FundRequest
    {
        [Required]
        public double Amount { get; set; }
    }
}
