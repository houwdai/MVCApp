using Microsoft.AspNetCore.Mvc;
using API.ViewModel;
using API.Repositories.Data;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var data = accountRepository.Login(login);
            if (data != null)
                return Ok(new { message = "berhasil Login", statusCode = 200, data = data });
            return BadRequest(new { message = "gagal Login, cek email & password", statusCode = 400 });
        }
    }
}
