using DBOperationsWithEFCoreApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBOperationsWithEFCoreApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        [HttpGet("")]
        public IActionResult GetAllStudent()
        {
            var student = _appDbContext.Student.ToList();
            return Ok(student);
        }

    }
}
