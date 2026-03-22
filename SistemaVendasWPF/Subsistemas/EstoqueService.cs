namespace SistemaVendasWPF.Subsistemas;

public class EstoqueService
{
    public bool VerificarDisponibilidade(int produtoId, int quantidade)
    {
        return true; // Simula que tem no estoque
    }
    public void BaixarEstoque(int produtoId, int quantidade)
    {
        // Lógica real de baixar estoque 
    }
}