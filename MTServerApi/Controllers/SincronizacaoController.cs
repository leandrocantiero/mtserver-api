using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mtvendors_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SincronizacaoController : ControllerBase
    {
        public SincronizacaoController(DbContext context)
        {
        }
    }
}
