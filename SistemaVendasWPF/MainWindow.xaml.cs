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
            // VALIDAÇÃO E CAPTURA DOS DADOS DIGITADOS NA TELA
            
            // Tenta converter o que foi digitado no campo de valor para número
            if (!decimal.TryParse(txtValor.Text, out decimal valorTotal))
            {
                txtStatus.Text = "Erro: Digite um valor válido.";
                txtStatus.Foreground = Brushes.Red;
                return;
            }

            string cartao = txtCartao.Text;
            string email = txtEmail.Text;

            
            if (string.IsNullOrWhiteSpace(cartao) || string.IsNullOrWhiteSpace(email))
            {
                txtStatus.Text = "Erro: Preencha o cartão e o e-mail.";
                txtStatus.Foreground = Brushes.Red;
                return;
            }
            
            int produtoId = 101; 
            int qtde = 1;

            // CHAMA A FACHADA 
            string resultado = _vendaFacade.FinalizarPedido(produtoId, qtde, valorTotal, cartao, email);

            // MOSTRA O RESULTADO NA TELA
            txtStatus.Text = resultado;
            txtStatus.Foreground = resultado.Contains("Sucesso") ? Brushes.Green : Brushes.Red;
            
            // desabilita o botão para não clicar duas vezes
            if (resultado.Contains("Sucesso")) btnFinalizar.IsEnabled = false;
        }
        catch (Exception ex)
        {
            txtStatus.Text = $"Erro: {ex.Message}";
            txtStatus.Foreground = Brushes.Red;
        }
    }
}