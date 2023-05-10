using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using mtvendors_api.DAL.IRepository;
using mtvendors_api.Models;
using Newtonsoft.Json;

namespace mtvendors_api.DAL.Repository
{
    public class DatabaseRepository : IDatabaseRepository
    {
        public DatabaseConn? Get()
        {
            var connectionString = AppSettings.GetValue("ConnectionString");

            if (string.IsNullOrEmpty(connectionString))
                return null;

            return new DatabaseConn(connectionString);
        }

        public string GetDatabaseStructure(DatabaseConn databaseConn)
        {
            var connectionString = databaseConn.ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            using (DataContext dbContext = new DataContext(optionsBuilder.Options))
            {
                try
                {
                    return dbContext.Database.GenerateCreateScript();
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
        }

        public void Set(DatabaseConn databaseConn)
        {
            AppSettings.SetValue("ConnectionString", databaseConn.ConnectionString);
        }

        public bool CreateDatabase(DatabaseConn databaseConn)
        {
            var connectionString = databaseConn.ConnectionString;
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            using (DataContext dbContext = new DataContext(optionsBuilder.Options))
            {
                try
                {
                    if (dbContext.Database.EnsureCreated())
                    {
                        Set(databaseConn);
                        RunSeeds(dbContext);
                        dbContext.SaveChanges();
                    } else
                    {
                        dbContext.Database.EnsureDeleted();
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        private void RunSeeds(DataContext dbContext)
        {
            dbContext.Propriedades.AddRange(new List<Propriedade>
            {
                new Propriedade { Nome = "PERMITE_ALTERAR_TABELA_PRECO_CLIENTE", Descricao = "", Sequencia = 1, Valor = "S" },
                new Propriedade { Nome = "FILTRAR_TABELAS_PRECO_HISTORICO_CLIENTE", Descricao = "", Sequencia = 2, Valor = "S" },
                new Propriedade { Nome = "PERMITE_ALTERAR_FORMA_PGTO_CLIENTE", Descricao = "", Sequencia = 3, Valor = "S" },
                new Propriedade { Nome = "FILTRAR_FORMA_PGTO_HISTORICO_CLIENTE", Descricao = "", Sequencia = 4, Valor = "S" },
                new Propriedade { Nome = "PERMITE_ALTERAR_COND_PGTO_CLIENTE", Descricao = "", Sequencia = 5, Valor = "S" },
                new Propriedade { Nome = "FILTRAR_COND_PGTO_HISTORICO_CLIENTE", Descricao = "", Sequencia = 6, Valor = "S" },
                new Propriedade { Nome = "pedidos.tempo_permanencia", Descricao = "", Sequencia = 7, Valor = "S" },
                new Propriedade { Nome = "PRAZO_MAXIMO_TITULOS_ATRASO", Descricao = "", Sequencia = 8, Valor = "S" },
                new Propriedade { Nome = "ACAO_TITULOS_ATRASO", Descricao = "", Sequencia = 9, Valor = "S" },
                new Propriedade { Nome = "mtvendors.periodoMaximoConexao", Descricao = "", Sequencia = 10, Valor = "S" },
                new Propriedade { Nome = "BLOQUEAR_LIMITE_CREDITO_EXCEDIDO", Descricao = "", Sequencia = 11, Valor = "S" },
                new Propriedade { Nome = "PERMITE_CADASTRAR_DESCONTO_ACIMA", Descricao = "", Sequencia = 12, Valor = "S" },
                new Propriedade { Nome = "PERMITE_VENDA_ACIMA_ESTOQUE", Descricao = "", Sequencia = 13, Valor = "S" },
                new Propriedade { Nome = "UF_EMPRESA", Descricao = "", Sequencia = 14, Valor = "S" },
                new Propriedade { Nome = "POLITICA_VENDA_CLIENTE_FILIAL", Descricao = "", Sequencia = 15, Valor = "S" },
                new Propriedade { Nome = "VOLUME_QUANTIDADE_VENDA", Descricao = "", Sequencia = 16, Valor = "S" },
                new Propriedade { Nome = "PERMITE_GRADES_PRODUTOS", Descricao = "", Sequencia = 17, Valor = "S" },
                new Propriedade { Nome = "BUSCAR_PRODUTOS_TABELA_PRECO_SELECIONADA", Descricao = "", Sequencia = 18, Valor = "S" },
                new Propriedade { Nome = "PERMITIR_VENDA_FRACIONADA", Descricao = "", Sequencia = 19, Valor = "S" },
                new Propriedade { Nome = "NOVO_CLIENTE_EMPRESA", Descricao = "", Sequencia = 20, Valor = "S" },
                new Propriedade { Nome = "NOVO_CLIENTE_FILIAL", Descricao = "", Sequencia = 21, Valor = "S" },
                new Propriedade { Nome = "NOVO_CLIENTE_TAB_PRECO", Descricao = "", Sequencia = 22, Valor = "S" },
                new Propriedade { Nome = "NOVO_CLIENTE_COND_PAG", Descricao = "", Sequencia = 23, Valor = "S" },
                new Propriedade { Nome = "NOVO_CLIENTE_FORMA_PAG", Descricao = "", Sequencia = 24, Valor = "S" },
                new Propriedade { Nome = "EXP_ITEMPED_PRECO", Descricao = "", Sequencia = 25, Valor = "S" },
                new Propriedade { Nome = "EXP_PED_INDCOMPRADOR", Descricao = "", Sequencia = 26, Valor = "S" },
                new Propriedade { Nome = "EXP_PED_CLASSIFICACAO", Descricao = "", Sequencia = 27, Valor = "S" },
                new Propriedade { Nome = "PERMITE_CADASTRO_CLIENTE", Descricao = "", Sequencia = 28, Valor = "S" },
                new Propriedade { Nome = "UTILIZA_MATRIZ_GRADE_PRODUTO_VENDA", Descricao = "", Sequencia = 29, Valor = "S" },
                new Propriedade { Nome = "END_MTVENDORS_WEB_API", Descricao = "", Sequencia = 30, Valor = "S" },
                new Propriedade { Nome = "PORTA_MTVENDORS_WEB_API", Descricao = "", Sequencia = 31, Valor = "S" },
                new Propriedade { Nome = "PEDIDO_CADASTRO_DIALOG_SOLICITAR_VALOR_FRETE_TONELADA", Descricao = "", Sequencia = 32, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.TAB_PRECO.SELECAO.FILTRO.CLIENTE", Descricao = "", Sequencia = 33, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.GRADE.CONFIGURACAO.GRADE_HORIZONTAL", Descricao = "", Sequencia = 34, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.GRADE.CONFIGURACAO.GRADE_VERTICAL", Descricao = "", Sequencia = 35, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.GRADE.CONFIGURACAO.GRADE_PAGINA", Descricao = "", Sequencia = 36, Valor = "S" },
                new Propriedade { Nome = "KETTLE.IMPORTACAO.CAMINHO.ARQUIVO_CHEQUES", Descricao = "", Sequencia = 37, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CONSULTA.PDF.ENVIO", Descricao = "", Sequencia = 38, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CONSULTA.PDF.INFORMACOES.IMPOSTOS", Descricao = "", Sequencia = 39, Valor = "S" },
                new Propriedade { Nome = "EVENTOS.EXPORTACAO.PERIODO", Descricao = "", Sequencia = 40, Valor = "S" },
                new Propriedade { Nome = "SALDOFLEX.EXPORTACAO.PERIODO", Descricao = "", Sequencia = 41, Valor = "S" },
                new Propriedade { Nome = "PERMITE.SALDO_FLEX", Descricao = "", Sequencia = 42, Valor = "S" },
                new Propriedade { Nome = "PERMITE.SALDO_FLEX.GERAR_DEBITO.DESCONTO_ABAIXO_POLITICA", Descricao = "", Sequencia = 43, Valor = "S" },
                new Propriedade { Nome = "SALDO_FLEX.PERCENTUAL_MAXIMO", Descricao = "", Sequencia = 44, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.TRANSPORTADORA", Descricao = "", Sequencia = 45, Valor = "S" },
                new Propriedade { Nome = "EXP_ITEM_PED_ORDEM_COMPRA", Descricao = "", Sequencia = 46, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.FORMA_PAGAMENTO.UTILIZA", Descricao = "", Sequencia = 47, Valor = "S" },
                new Propriedade { Nome = "EXP_PED_ESPECIE", Descricao = "", Sequencia = 48, Valor = "S" },
                new Propriedade { Nome = "EXP_PED_RATEIO", Descricao = "", Sequencia = 49, Valor = "S" },
                new Propriedade { Nome = "EXP_ITEM_PED_UTILIZA_CLASSIFICACAO", Descricao = "", Sequencia = 50, Valor = "S" },
                new Propriedade { Nome = "EXP_ITEM_PED_UTILIZA_GERENCIAL", Descricao = "", Sequencia = 51, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.TIPO_FRETE.UTILIZA", Descricao = "", Sequencia = 52, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.DATA_ENTREGA.PRAZO_MINIMO", Descricao = "", Sequencia = 53, Valor = "S" },
                new Propriedade { Nome = "PEDIDO.CADASTRO.OP_COMERCIAL", Descricao = "", Sequencia = 54, Valor = "S" },
                new Propriedade { Nome = "UTILIZAR_CFOP_CATEGORIA", Descricao = "", Sequencia = 55, Valor = "S" },
                new Propriedade { Nome = "COND_PGTO_ZERAR_DESCONTO", Descricao = "", Sequencia = 56, Valor = "S" },
                new Propriedade { Nome = "GERA_INFOR_CAT_CLI_PEDIDO", Descricao = "", Sequencia = 57, Valor = "S" },
            });
        }
    }
}
