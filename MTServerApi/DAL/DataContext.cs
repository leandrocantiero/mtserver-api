using Microsoft.EntityFrameworkCore;
using mtvendors_api.Models.DAO;
using System.ComponentModel.DataAnnotations.Schema;

namespace mtvendors_api.DAL
{
    public class DataContext : DbContext
    {
        public int DatabaseVersion { get; } = 100;

        public DataContext(DbContextOptions options) : base(options)
        { }

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

        public DbSet<AgendaVisita> AgendaVisitas { get; set; }
        public DbSet<AutorizacaoPedido> AutorizacaoPedidos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Cobranca> Cobrancas { get; set; }
        public DbSet<CondPgto> CondPgtos { get; set; }
        public DbSet<ContatoCliente> ContatosCliente { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<EnderecoCobranca> EnderecosCobranca { get; set; }
        public DbSet<EnderecoEntrega> EnderecosEntrega { get; set; }
        public DbSet<EstoqueDisponivel> EstoqueDisponiveis { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<FamiliaProduto> FamiliaProdutos { get; set; }
        public DbSet<FaturamentoPedido> FaturamentosPedido { get; set; }
        public DbSet<Filial> Filiais { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<HistoricoCliente> HistoricosCliente { get; set; }
        public DbSet<Imagem> Imagens { get; set; }
        public DbSet<JustificativaPedido> JustificativasPedido { get; set; }
        public DbSet<Meta> Metas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Propriedade> Propriedades { get; set; }
        public DbSet<RelFilialCondPgto> RelFilialCondPgtos { get; set; }
        public DbSet<RelClienteTabelaPreco> RelClienteTabelaPrecos { get; set; }
        public DbSet<RelCondPgtoTabelaPreco> RelCondPgtoTabelaPrecos { get; set; }
        public DbSet<RelVendedorTabelaPreco> RelVendedorTabelaPrecos { get; set; }
        public DbSet<SituacaoPedido> SituacoesPedido { get; set; }
        public DbSet<SysConfig> SysConfig { get; set; }
        public DbSet<TabelaPreco> TabelasPreco { get; set; }
        public DbSet<TipoCobranca> TiposCobranca { get; set; }
        public DbSet<Titulo> Titulos { get; set; }
        public DbSet<Transportadora> Transportadoras { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
    }
}
