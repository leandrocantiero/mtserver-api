using Microsoft.EntityFrameworkCore;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models.DAO;
using mtvendors_api.Models.Helpers;
using mtvendors_api.Models.parameters;

namespace mtvendors_api.DAL.Repository
{
    public class MetaRepository : IMetaRepository
    {
        private DataContext context;

        public MetaRepository(DataContext context)
        {
            this.context = context;
        }

        public void Insert(Meta meta)
        {
            context.Metas.Add(meta);
        }

        public void Update(Meta meta)
        {
            context.Entry(meta).State = EntityState.Modified;
        }

        public PagedResult<Meta> Get(MetaParameters parameters)
        {
            var result = new PagedResult<Meta>();
            var skip = (parameters.PageNumber - 1) * parameters.PageSize;
            var metas = context.Metas.ToList();

            result.Count = metas.Count;

            if (parameters.FkFilial != null && parameters.FkFilial != 0)
            {
                metas = metas.Where(o => o.FkFilial == parameters.FkFilial).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.FkVendedor))
            {
                metas = metas.Where(o => o.FkVendedor.Equals(parameters.FkVendedor)).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.FkClienteCnpjCpf))
            {
                metas = metas.Where(o => o.FkClienteCnpjCpf.Equals(parameters.FkClienteCnpjCpf)).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.FkProduto))
            {
                metas = metas.Where(o => o.FkProduto.Equals(parameters.FkProduto)).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.FkFamilia))
            {
                metas = metas.Where(o => o.FkFamilia.Equals(parameters.FkFamilia)).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.Periodo))
            {
                metas = metas.Where(o => o.Periodo.Contains(parameters.Periodo)).ToList();
            }

            // pesquisar como melhorar a sintaxe desses joins
            result.Data = metas
                .SortBy(parameters.OrderBy)
                .Skip(skip).Take(parameters.PageSize)
                .Join(context.Vendedores, m => m.FkVendedor, v => v.Codigo, (m, v) => new { Meta = m, Vendedor = v.Nome }) // join do vendedor
                .Join(context.Clientes, o => o.Meta.FkClienteCnpjCpf, c => c.CnpjCpf, (o, c) => new { o.Meta, o.Vendedor, Cliente = c.RazaoSocial })// join do cliente
                .Join(context.Produtos, o => o.Meta.FkProduto, p => p.Codigo, (o, p) => new { o.Meta, o.Vendedor, o.Cliente, Produto = p.Descricao })// join do produto
                .Join(context.FamiliaProdutos, o => o.Meta.FkFamilia, f => f.Codigo, (o, f) => new { o.Meta, o.Vendedor, o.Cliente, o.Produto, FamiliaProduto = f.Descricao }) // join da familia do produto
                .Select(p => new Meta
                {
                    FkFilial = p.Meta.FkFilial,
                    FkVendedor = p.Meta.FkVendedor,
                    Vendedor = p.Vendedor,
                    FkProduto = p.Meta.FkProduto,
                    Produto = p.Produto,
                    FkFamilia = p.Meta.FkFamilia,
                    FamiliaProduto = p.FamiliaProduto,
                    FkClienteCnpjCpf = p.Meta.FkClienteCnpjCpf,
                    Cliente = p.Cliente,
                    Periodo = p.Meta.Periodo,
                    Quantidade = p.Meta.Quantidade,
                    Valor = p.Meta.Valor
                }).ToList();

            return result;
        }

        public Meta? GetByKey(MetaParameters parameters)
        {
            return context.Metas.SingleOrDefault(o =>
                o.FkVendedor == parameters.FkVendedor &&
                o.FkFilial == parameters.FkFilial &&
                o.FkClienteCnpjCpf == parameters.FkClienteCnpjCpf &&
                o.FkProduto == parameters.FkProduto &&
                o.FkFamilia == parameters.FkFamilia);
        }

        public void Remove(Meta meta)
        {
            var metadb = context.Metas.SingleOrDefault(o =>
                o.FkVendedor == meta.FkVendedor &&
                o.FkFilial == meta.FkFilial &&
                o.FkClienteCnpjCpf == meta.FkClienteCnpjCpf &&
                o.FkProduto == meta.FkProduto &&
                o.FkFamilia == meta.FkFamilia);
            context.Metas.Remove(metadb);
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
