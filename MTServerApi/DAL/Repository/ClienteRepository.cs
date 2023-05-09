using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private DataContext context;

        public ClienteRepository(DataContext context)
        {
            this.context = context;
        }

        public PagedResult<Cliente> Get(ClienteParameters parameters)
        {
            var result = new PagedResult<Cliente>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var clientes = context.Clientes.ToList();

            result.Count = clientes.Count;

            if (!string.IsNullOrEmpty(parameters.NomeOrEmail))
            {
                clientes = clientes.Where(o =>
                    o.RazaoSocial != null && o.RazaoSocial.ToUpper().Contains(parameters.NomeOrEmail.ToUpper()) ||
                    o.Email != null && o.Email.ToUpper().Contains(parameters.NomeOrEmail.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.CnpjCpf))
            {
                clientes = clientes.Where(o =>
                    o.CnpjCpf != null && o.CnpjCpf.Contains(parameters.CnpjCpf.ToUpper())).ToList();
            }

            result.Data = clientes.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public Cliente? GetByCodigo(string codigo)
        {
            return context.Clientes.Find(codigo);
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
