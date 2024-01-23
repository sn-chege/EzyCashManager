using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMService.Models
{
    public class ATM
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        public string Location { get; set; }

        public double Balance { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("created_on")]
        public DateTime CreatedOn { get; set; }

    }
}
