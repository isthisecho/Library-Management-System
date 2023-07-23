using Library.API.Services;
using LibraryManagementSystem.API.Entities;
using LibraryManagementSystem.DataLayer.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ILogger<TransactionController>     logger      ;
        private readonly ITransactionService _transactionService;
        public TransactionController(ILogger<TransactionController> logger, ITransactionService transactionService)
        {
            this.logger = logger   ;
            _transactionService = transactionService;
        }

        [HttpPost(Name = "BorrowBook")]
        public IActionResult BorrowBook([FromBody] Transaction transaction)
        {

                Transaction? createdTransaction = _transactionService.BorrowBook(transaction).Result;
                return Ok(createdTransaction);
        }



        [HttpDelete("{id}", Name = "RefundBook")]
        public IActionResult RefundBook(Guid id)
        {
            Transaction? selectedTransaction = _transactionService.GetTransactionById(id).Result;

            if (selectedTransaction != null)
            {
                _transactionService.RefundBook(id);
                return Ok();
            }

            return NotFound();
        }


    }
}
