using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

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

            //viewModel = (MainWindowViewMode)DataContext;            
        }

        private void ButtonValidateInput(object sender, RoutedEventArgs e)
        {           
        }        
    }

    class RadioButtonBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value == null || parameter == null) return false;
            string checkValue = value.ToString();
            string targetValue = parameter.ToString();
            return checkValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            CultureInfo culture)
        {
            if (value == null || parameter == null)
                return null;
            bool useValue = (bool)value;
            string targetValue = parameter.ToString();
            if (useValue)
                return Enum.Parse(targetType, targetValue);
            return null;
        }
    }
}
