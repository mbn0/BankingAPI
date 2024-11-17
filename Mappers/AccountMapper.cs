using banking.Model;
using banking.Dtos.BankAccountDtos;

namespace banking.Mappers
{

    public static class AccountMapper
    {

        public static AccountDto ToAccountDto(this BankAccount acc)
        {
            return new AccountDto
            {
                Number = acc.Number,
                Balance = acc.Balance,
                IsActive = acc.IsActive,
                HolderName = acc.HolderName,
                DateOfBirth = acc.DateOfBirth,
                CreationDate = acc.CreationDate,
                AssociatedPhoneNumber = acc.AssociatedPhoneNumber,
            };
        }

        public static BankAccount AddToBankAccount(this AddAccountDto acc, string num)
        {
            return new BankAccount
            {
                Number = num,
                Balance = acc.Balance,
                HolderName = acc.HolderName,
                DateOfBirth = acc.DateOfBirth,
                CreationDate = DateTime.Today,
                AssociatedPhoneNumber = acc.AssociatedPhoneNumber,
            };
        }

    }
}



