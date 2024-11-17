using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace banking.Model
{
    public class BankAccount 
    {
        [Key]
        [Required]
        public string Number { get; set; } = string.Empty;

        [Required]
        [MaxLength(35)]
        public string HolderName { get; set; } = string.Empty;

        [MaxLength(13)]
        public string AssociatedPhoneNumber { get; set; } = string.Empty;

        [Required]
        public bool IsActive { get; set; } = true;

        [Column(TypeName = "decimal(18,3)")] // considering we are using KWD
        public decimal Balance { get; set; }

        public DateTime CreationDate { get; set; } 

        public DateOnly DateOfBirth { get; set; } 
    }
}
