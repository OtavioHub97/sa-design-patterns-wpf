using System;
using System.Windows;
using System.Windows.Media;
using SistemaVendasWPF.PadraoGoF;

namespace SistemaVendasWPF;

public partial class MainWindow : Window
{
    private VendaFacade _vendaFacade;

    public MainWindow()
    {
        InitializeComponent();
        _vendaFacade = new VendaFacade();
    }

    private void btnFinalizar_Click(object sender, RoutedEventArgs e)
    {
        txtStatus.Text = "Processando...";
        txtStatus.Foreground = Brushes.Black;

        try
        {
            // Dados simulados da UI
            int produtoId = 101;
            int qtde = 1;
            decimal valorTotal = 1500.00m;
            string cartao = txtCartao.Text;
            string email = txtEmail.Text;

            // CHAMA A FACHADA (Padrão GoF em ação)
            string resultado = _vendaFacade.FinalizarPedido(produtoId, qtde, valorTotal, cartao, email);

            txtStatus.Text = resultado;
            txtStatus.Foreground = resultado.Contains("Sucesso") ? Brushes.Green : Brushes.Red;
            
            if (resultado.Contains("Sucesso")) btnFinalizar.IsEnabled = false;
        }
        catch (Exception ex)
        {
            txtStatus.Text = $"Erro: {ex.Message}";
            txtStatus.Foreground = Brushes.Red;
        }
    }
}