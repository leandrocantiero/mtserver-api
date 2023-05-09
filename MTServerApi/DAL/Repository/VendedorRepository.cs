using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;
using static System.Net.Mime.MediaTypeNames;

namespace mtvendors_api.DAL.Repository
{
    public class VendedorRepository : IVendedorRepository
    {
        private DataContext context;

        public VendedorRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(Vendedor vendedor)
        {
            if (vendedor.Codigo == null || vendedor.Codigo.Equals(""))
            {
                vendedor.Codigo = GetNewCodigo();
            }

            if (context.Vendedores.Count() == 0)
            {
                vendedor.Tipo = "1";
            }
            else
            {
                vendedor.Tipo = "0";
            }

            context.Vendedores.Add(vendedor);
        }

        private string GetNewCodigo()
        {
            int.TryParse(context.Vendedores.OrderBy(i => i.Codigo).LastOrDefault()?.Codigo, out var lastCodigo);

            if (lastCodigo != 0 || context.Vendedores.Count() == 0)
            {
                lastCodigo += 1;
                return lastCodigo.ToString();
            } else
            {
                return AlfanumericoAleatorio(5);
            }

        }

        private string AlfanumericoAleatorio(int tamanho)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, tamanho)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }

        public void Update(Vendedor vendedor)
        {
            context.Entry(vendedor).State = EntityState.Modified;
        }

        public PagedResult<Vendedor> Get(VendedorParameters parameters)
        {
            var result = new PagedResult<Vendedor>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var vendedores = context.Vendedores.ToList();

            result.Count = vendedores.Count;

            if (!string.IsNullOrEmpty(parameters.Nome))
            {
                vendedores = vendedores.Where(o => o.Nome != null && o.Nome.ToUpper().Contains(parameters.Nome.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.Email))
            {
                vendedores = vendedores.Where(o => o.Email != null && o.Email.ToUpper().Contains(parameters.Email.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.NomeOrEmail))
            {
                vendedores = vendedores.Where(o =>
                    o.Nome != null && o.Nome.ToUpper().Contains(parameters.NomeOrEmail.ToUpper()) ||
                    o.Email != null && o.Email.ToUpper().Contains(parameters.NomeOrEmail.ToUpper())
                ).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.CodigoSupervisor))
            {
                vendedores = vendedores.Where(o => o.CodigoSupervisor != null && o.CodigoSupervisor.ToUpper().Contains(parameters.CodigoSupervisor.ToUpper())).ToList();
            }

            if (parameters.SupervisorsOnly != null && parameters.SupervisorsOnly == true)
            {
                vendedores = vendedores.Where(o => o.Tipo != null && o.Tipo == "1").ToList();
            }

            result.Data = vendedores
                .SortBy(parameters.OrderBy)
                .Skip(skip).Take(parameters.PageSize)
                .Select(p => new Vendedor
                {
                    Codigo = p.Codigo,
                    Nome = p.Nome,
                    Email = p.Email,
                    Senha = p.Senha,
                    CodigoSupervisor = p.CodigoSupervisor,
                    Supervisor = GetNomeSupervisor(p.CodigoSupervisor),
                    Tipo = p.Tipo,
                    SenhaCaixaPostal = p.SenhaCaixaPostal,
                    AtualizaSaldoFlex = p.AtualizaSaldoFlex,
                    SysRestoreTablet = p.SysRestoreTablet
                }).ToList();

            return result;
        }

        private string GetNomeSupervisor(string? codigoSupervisor)
        {
            if (codigoSupervisor == null)
                return "";

            var supervisor = context.Vendedores.Where(p => p.Codigo == codigoSupervisor).SingleOrDefault();
            if (supervisor == null)
            {
                return "";
            }
            else
            {
                return supervisor.Nome;
            }
        }

        public Vendedor? GetByCodigo(string codigo)
        {
            return context.Vendedores.Find(codigo);
        }

        public Vendedor? GetByAuth(string codigo, string senha)
        {
            return context.Vendedores.SingleOrDefault(o => o.Codigo.Equals(codigo) && o.Senha.Equals(senha));
        }

        public void Remove(string codigo)
        {
            var vendedor = context.Vendedores.Find(codigo);
            context.Vendedores.Remove(vendedor);
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
