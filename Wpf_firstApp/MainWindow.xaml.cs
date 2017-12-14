using System.Windows;

namespace Wpf_firstApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewMode viewModel;

        public MainWindow()
        {
            InitializeComponent();

            viewModel = (MainWindowViewMode)DataContext;            
        }

        private void ButtonValidateInput(object sender, RoutedEventArgs e)
        {
            /*viewModel.Num1 = txtnumber1.Text;
            viewModel.Num2 = txtnumber2.Text;

            viewModel.operation = CheckRadionButton();
            viewModel.CalculateNumbers();
            if (!string.IsNullOrEmpty(viewModel.Msg))
            {
                txtResult.Text = viewModel.Msg;
            }
            else if (viewModel.Result != null)
            {
                txtResult.Text = viewModel.Result.ToString();
            } */                           
        }        
    }
}
