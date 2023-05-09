using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                var connectionString = AppSettings.GetValue("ConnectionString");
                if (!string.IsNullOrEmpty(connectionString))
                {
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meta>()
                .HasKey(o => new { o.FkFilial, o.FkVendedor, o.FkClienteCnpjCpf, o.FkProduto, o.FkFamilia });

            modelBuilder.Entity<RelFilialCondPgto>()
                .HasKey(o => new { o.FkEmpresa, o.FkFilial, o.FkCondicaoPagamento });

            modelBuilder.Entity<RelCondPgtoTabelaPreco>()
                .HasKey(o => new { o.FkEmpresa, o.FkFilial, o.FkCondicaoPagamento, o.FkTabelaPreco, o.FkVendedor, o.FkClienteCnpj });

            modelBuilder.Entity<RelVendedorTabelaPreco>()
                .HasKey(o => new { o.FkVendedor, o.FkEmpresa, o.FkTabelaPreco });

            modelBuilder.Entity<RelClienteTabelaPreco>()
                .HasKey(o => new { o.FkFilial, o.FkClienteCpfCnpj, o.FkEmpresa, o.FkTabelaPreco });
        }

        public DbSet<Filial> Filiais { get; set; }

        public DbSet<Empresa> Empresas { get; set; }

        public DbSet<SituacaoPedido> SituacoesPedido { get; set; }

        public DbSet<JustificativaPedido> JustificativasPedido { get; set; }

        public DbSet<Meta> Metas { get; set; }

        public DbSet<Vendedor> Vendedores { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<FamiliaProduto> FamiliaProdutos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        public DbSet<TabelaPreco> TabelasPreco { get; set; }

        public DbSet<CondPgto> CondPgtos { get; set; }

        public DbSet<Propriedade> Propriedades { get; set; }

        public DbSet<RelFilialCondPgto> RelFilialCondPgtos { get; set; }

        public DbSet<RelClienteTabelaPreco> RelClienteTabelaPrecos { get; set; }

        public DbSet<RelCondPgtoTabelaPreco> RelCondPgtoTabelaPrecos { get; set; }

        public DbSet<RelVendedorTabelaPreco> RelVendedorTabelaPrecos { get; set; }
    }
}
