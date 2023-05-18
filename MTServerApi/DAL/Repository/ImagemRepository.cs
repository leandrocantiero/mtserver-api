using Cicada.EntityFrameworkCore.Extension;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace mtvendors_api.DAL.Repository
{
    public class ImagemRepository : IImagemRepository
    {
        private DataContext context;
        private readonly string pathImagens = Path.Combine(AppContext.BaseDirectory, "imagens");

        public ImagemRepository(DataContext context)
        {
            this.context = context;

            if (!Directory.Exists(pathImagens))
            {
                Directory.CreateDirectory(pathImagens);
            }
        }

        public void Create(List<Imagem> imagens)
        {
            foreach (var imagem in imagens)
            {
                var imagemdb = GetByNome(imagem.Nome);

                if (imagemdb == null)
                {
                    context.Imagens.Add(imagem);
                } else
                {
                    context.Entry(imagem).State = EntityState.Modified;
                }
            }
        }

        public List<Imagem> Upload(List<IFormFile> files)
        {
            List<Imagem> imagens = new List<Imagem>();

            foreach (var file in files)
            {
                using (var stream = File.Create(Path.Combine(pathImagens, file.FileName)))
                {
                    file.CopyTo(stream);

                    var imagem = new Imagem
                    {
                        Nome = file.FileName,
                        Data = DateOnly.FromDateTime(DateTime.Now),
                        Hora = TimeOnly.FromDateTime(DateTime.Now)
                    };

                    imagem.Hash = GetHash(imagem);

                    imagens.Add(imagem);
                }
            }

            return imagens;
        }

        private string GetHash(Imagem imagem)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(imagem.ToString()));
                var sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

        public PagedResult<Imagem> Get(ImagemParameters parameters)
        {
            var result = new PagedResult<Imagem>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var imagens = context.Imagens.ToList();

            result.Count = imagens.Count;

            if (!string.IsNullOrEmpty(parameters.Nome))
            {
                imagens = imagens.Where(o => o.Nome.ToUpper().Contains(parameters.Nome.ToUpper())).ToList();
            }

            result.Data = imagens.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public Imagem? GetByNome(string nome)
        {
            return context.Imagens.Find(nome);
        }

        public string? GetBase64ByNome(string nome)
        {
            byte[] imageArray = File.ReadAllBytes(Path.Combine(pathImagens, nome));
            return Convert.ToBase64String(imageArray);
        }

        public void Remove(string nome)
        {
            var imagem = context.Imagens.Find(nome);

            if (imagem != null)
            {
                RemoveFile(nome);
                context.Imagens.Remove(imagem);
            }
        }

        private void RemoveFile(string nome)
        {
            var path = Path.Combine(pathImagens, nome);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool Disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            Disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
