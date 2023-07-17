using LibraryManagementSystem.DataLayer.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger     ;
        private readonly LibraryDbContext        _dbContext  ;
        public BookController(ILogger<BookController> logger, LibraryDbContext dbContext)
        {
            this.logger = logger    ;
            _dbContext  = dbContext ;
        }

    }
}
