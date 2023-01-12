using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private DataContext context;

        public EmpresaRepository(DataContext context)
        {
            this.context = context;
        }

        public PagedResult<Empresa> GetEmpresas(EmpresaParameters parameters)
        {
            var result = new PagedResult<Empresa>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var empresas = context.Empresas.ToList();

            result.Count = empresas.Count;

            if (!string.IsNullOrEmpty(parameters.Nome))
            {
                empresas = empresas.Where(o => o.Nome != null && o.Nome.ToUpper().Contains(parameters.Nome.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.UF))
            {
                empresas = empresas.Where(o => o.UF != null && o.UF.ToUpper().Contains(parameters.UF.ToUpper())).ToList();
            }

            result.Data = empresas.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public PagedResult<Filial> GetFiliais(EmpresaParameters parameters)
        {
            var result = new PagedResult<Filial>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var filiais = context.Filiais.ToList();

            result.Count = filiais.Count;

            if (!string.IsNullOrEmpty(parameters.Nome))
            {
                filiais = filiais.Where(o => o.Nome != null && o.Nome.ToUpper().Contains(parameters.Nome.ToUpper())).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.UF))
            {
                filiais = filiais.Where(o => o.UF != null && o.UF.ToUpper().Contains(parameters.UF.ToUpper())).ToList();
            }

            result.Data = filiais.SortBy(parameters.OrderBy).Skip(skip).Take(parameters.PageSize).ToList();
            return result;
        }

        public Empresa? GetEmpresaByCodigo(string codigo)
        {
            return context.Empresas.Find(codigo);
        }

        public Filial? GetFilialByCodigo(string codigo)
        {
            return context.Filiais.Find(codigo);
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
