using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoRepository produtoRepository;

        public ProdutoController(DataContext context)
        {
            produtoRepository = new ProdutoRepository(context);
        }

        [HttpGet("Get")]
        public PagedResult<Produto> Get([FromQuery] ProdutoParameters parameters)
        {
            return produtoRepository.Get(parameters);
        }
    }
}
