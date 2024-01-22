using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;


namespace AccountService.Models
{

    [Table("account")]
    public class Account
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Required]
        [Column("user_id")]
        public int UserId { get; set; }

        [Required]
        [Column("account_type")]
        public string AccountType { get; set; }

        [Column("account_balance", TypeName = "decimal(18, 2)")]
        public double Balance { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

        public Account()
        {
            // Generate a unique 14-digit account number
            AccountNumber = GenerateUniqueAccountNumber();
        }

        private string GenerateUniqueAccountNumber()
        {
            // Logic to generate a unique account number
            string timestampPart = DateTime.Now.ToString("yyyyMMddHHmmss");
            string randomPart = new Random().Next(100000, 999999).ToString();
            return timestampPart + randomPart;
        }
    }


}
