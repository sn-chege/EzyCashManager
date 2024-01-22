using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountService.Models
{
    [Table("transaction")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(8)]
        [Column("reference_code")]
        public string ReferenceCode { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be greater than or equal to 0")]
        [Column("amount", TypeName = "decimal(18, 2)")]
        public double Amount { get; set; }

        [Required]
        [Column("sender_account_id")]
        public int SenderAccountId { get; set; }

        [Column("recipient_account_id")]
        public System.Nullable<int> RecipientAccountId { get; set; }

        [Required]
        [Column("action")]
        public string TransactionAction { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }
    }

}
