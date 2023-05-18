using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.IRepository
{
    public interface IImagemRepository : IDisposable
    {
        void Create(List<Imagem> imagens);

        List<Imagem> Upload(List<IFormFile> files);

        PagedResult<Imagem> Get(ImagemParameters parameters);

        Imagem? GetByNome(string nome);

        string? GetBase64ByNome(string nome);

        void Remove(string nome);

        void Save();
    }
}
