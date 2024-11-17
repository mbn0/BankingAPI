namespace banking.Dtos.BankAccountDtos
{
    public class AddAccountDto
    {
        public string HolderName { get; set; } = string.Empty;

        public string AssociatedPhoneNumber { get; set; } = string.Empty;

        public decimal Balance { get; set; }

        public DateOnly DateOfBirth { get; set; } 
    }
}



