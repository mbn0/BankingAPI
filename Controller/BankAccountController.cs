using banking.Dtos.TransactionDtos;
using banking.Mappers;
using banking.Dtos.BankAccountDtos;
using Microsoft.AspNetCore.Mvc;
using banking.Data;
using Microsoft.EntityFrameworkCore;

namespace banking.Controller
{
    [Route("api/[controller]")] //
    //[Route("api/stocks")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly BankingDbContext context; // for security and stuff cause im cool

        public BankAccountController(BankingDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accs = await context.BankAccounts.ToListAsync();
            var accsDto = accs.Select(a => a.ToAccountDto());

            if (accs != null)
                return Ok(accsDto);
            return NotFound();
        }

        //get by id
        [HttpGet("{num}")]
        public async Task<IActionResult> GetAccountDetails([FromRoute] string num)
        {
            var acc = await context.BankAccounts.FindAsync(num);

            if (acc != null)
                return Ok(acc.ToAccountDto());
            return NotFound();
        }

        //post (add)
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddAccountDto accDto)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            var datePart = today.ToString("yyMMdd");
            var allAcc = await context.BankAccounts.ToListAsync();
            var maxSequence = allAcc
              .Select(account => int.Parse(account.Number.Substring(6)))
              .DefaultIfEmpty(0)
              .Max();
            var numbpart = maxSequence + 1;
            var num = $"{datePart}{numbpart}";

            var age = today.Year - accDto.DateOfBirth.Year;
            if (accDto.DateOfBirth > today.AddYears(-age)) age--; // today.AddYears, to see the birthday calculated vs real birthday
            if (age < 18)
                return BadRequest("Minimum age to open an account is 18");


            var acc = accDto.AddToBankAccount(num);
            await context.BankAccounts.AddAsync(acc);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAccountDetails), new { num = acc.Number }, acc.ToAccountDto());
        }

        //put (edit)
        [HttpPut("{num}")]
        public async Task<IActionResult> ModifyAccountDetails([FromRoute] string num, [FromBody] UpdateAccountDto accDto)
        {
            var acc = await context.BankAccounts.FindAsync(num);

            if (acc == null)
                return NotFound();
            acc.HolderName = accDto.HolderName;
            acc.AssociatedPhoneNumber = accDto.AssociatedPhoneNumber;

            await context.SaveChangesAsync();

            return NoContent();
        }
        //▪ Deposit: Adds a specified amount to an account’s balance.
        [HttpPut("{num}/Deposit")]
        public async Task<IActionResult> Deposit([FromRoute] string num, [FromBody] TransactionDto transaction)
        {
            if (transaction.Amount < 5)
                return BadRequest("The minimum deposit ammount is 5KD");
            else if (transaction.Amount > 100)
                return BadRequest("The maximum deposit ammount is 100KD");
            else
            {
                var acc = await context.BankAccounts.FindAsync(num);
                if (acc == null)
                    return NotFound();

                acc.Balance = acc.Balance + transaction.Amount;
                await context.SaveChangesAsync();
                return Ok(acc.ToAccountDto());

            }
        }

        //▪ Withdraw: Deducts a specified amount from an account’s balance.
        [HttpPut("{num}/Withdrawl")]
        public async Task<IActionResult> Withdrawl([FromRoute] string num, [FromBody] TransactionDto transaction)
        {
            if (transaction.Amount <= 5)
                return BadRequest("The minimum withdrawl ammount is 5KD");
            else if (transaction.Amount >= 20)
                return BadRequest("The maximum withdrawl ammount is 20KD");
            else
            {
                var acc = await context.BankAccounts.FindAsync(num);
                if (acc == null)
                    return NotFound();

                acc.Balance = acc.Balance + transaction.Amount;
                await context.SaveChangesAsync();
                return Ok(acc.ToAccountDto());

            }
        }

    }
}
