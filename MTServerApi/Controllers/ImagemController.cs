using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.DAL.Repository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;
using System.Data;

namespace mtvendors_api.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ImagemController : Controller
    {
        private IImagemRepository imagemRepository;

        public ImagemController(DataContext context)
        {
            imagemRepository = new ImagemRepository(context);
        }

        [HttpPost("Create")]
        public ActionResult Create(List<IFormFile> files)
        {
            if (files.Count == 0)
                return BadRequest("Selecione algumas imagens para salvar");

            try
            {
                var imagens = imagemRepository.Upload(files);
                imagemRepository.Create(imagens);
                imagemRepository.Save();

                return Ok();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        [HttpGet("Get")]
        public PagedResult<Imagem> Get([FromQuery] ImagemParameters parameters)
        {
            return imagemRepository.Get(parameters);
        }

        [HttpGet("GetByNome")]
        public Imagem? GetByNome([FromQuery] string nome)
        {
            return imagemRepository.GetByNome(nome);
        }

        [HttpGet("GetBase64ByNome")]
        public string? GetBase64ByNome([FromQuery] string nome)
        {
            return imagemRepository.GetBase64ByNome(nome);
        }

        [HttpDelete("Remove")]
        public ActionResult Remove([FromQuery] string nome)
        {
            try
            {
                var imagemdb = imagemRepository.GetByNome(nome);
                if (imagemdb == null)
                {
                    return BadRequest("O recurso que você tentou excluir não existe");
                }

                imagemRepository.Remove(nome);
                imagemRepository.Save();
                return Ok();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Não foi possivel concluir a operação");
            }
        }

        protected override void Dispose(bool disposing)
        {
            imagemRepository.Dispose();
            base.Dispose(disposing);
        }
    }
}
