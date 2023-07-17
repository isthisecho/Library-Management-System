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
        private readonly LibraryDbContext                   _dbContext  ;
        public TransactionController(ILogger<TransactionController> logger, LibraryDbContext dbContext)
        {
            this.logger = logger   ;
            _dbContext  = dbContext;
        }
    }
}
