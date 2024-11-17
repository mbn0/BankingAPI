namespace banking.Dtos.BankAccountDtos
{
    public class AccountDto
    {
        public string Number { get; set; } = string.Empty;

        public string HolderName { get; set; } = string.Empty;

        public string AssociatedPhoneNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        public decimal Balance { get; set; }

        public DateTime CreationDate { get; set; } 

        public DateOnly DateOfBirth { get; set; } 
    }
}

