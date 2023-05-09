namespace mtvendors_api.Models
{
    public class Sincronizacao
    {
        List<Cliente>? Clientes { get; set; }

        List<ContatoCliente>? ContatosClientes { get; set; }

        List<Pedido>? Pedidos { get; set; }

        List<SituacaoPedido>? SituacoesPedidos { get; set; }

        List<AutorizacaoPedido>? AutorizacoesPedidos { get; set; }

        List<HistoricoCliente>? HistoricosClientes { get; set; }

        List<FormaPagamento>? FormasPagamento { get; set; }

        List<CondPgto>? CondPgtos { get; set; }

        List<Imagem>? Imagens { get; set; }

        List<Titulo>? Titulos { get; set; }

        List<Meta>? Metas { get; set; }

        List<Propriedade>? Propriedades { get; set; }

        List<TipoCobranca>? TipoCobrancas { get; set; }

        List<Transportadora>? Transportadoras { get; set; }

        List<FamiliaProduto>? FamiliasProdutos { get; set; }
    }
}
