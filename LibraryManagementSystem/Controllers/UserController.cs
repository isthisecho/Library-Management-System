using LibraryManagementSystem.DataLayer.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LibraryDbContext _dbContext;
        private readonly ILogger<UserController> logger;

        public UserController(ILogger<UserController> logger, LibraryDbContext dbContext) 
        {
            this.logger = logger    ;
            _dbContext  = dbContext ;
        }


    }
}
