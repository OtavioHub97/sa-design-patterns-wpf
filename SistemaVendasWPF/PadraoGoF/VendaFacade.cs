using SistemaVendasWPF.Subsistemas;

namespace SistemaVendasWPF.PadraoGoF;

public class VendaFacade
{
    private EstoqueService _estoque;
    private PagamentoService _pagamento;
    private NotificacaoService _notificacao;

    public VendaFacade()
    {
        _estoque = new EstoqueService();
        _pagamento = new PagamentoService();
        _notificacao = new NotificacaoService();
    }

    public string FinalizarPedido(int produtoId, int qtde, decimal valor, string cartao, string email)
    {
        if (!_estoque.VerificarDisponibilidade(produtoId, qtde))
            return "Erro: Produto fora de estoque.";

        if (!_pagamento.ProcessarCartao(cartao, valor))
            return "Erro: Pagamento recusado.";

        _estoque.BaixarEstoque(produtoId, qtde);
        _notificacao.EnviarEmailConfirmacao(email);

        return "Sucesso: Venda finalizada com sucesso e e-mail enviado!";
    }
}