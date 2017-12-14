using System;
using System.ComponentModel;
using System.Windows.Input;

namespace Wpf_firstApp
{
    public class MainWindowViewMode : ViewModelBase
    {
        #region Attributes
        private string num1;
        private string num2;
        //private float result = 0;
        private Nullable<float> result = null;
        private string msg = string.Empty;
        internal string operation = string.Empty;
        #endregion

        #region GetterAndSetters
        public string Num1
        {
            get { return num1; }
            set
            {
                if (num1 != value)
                {
                    OnPropertyChanged(nameof(Num1));
                    num1 = value;
                }
            }

        }
        public string Num2
        {
            get { return num2; }
            set
            {
                if (num2 != value)
                {
                    OnPropertyChanged(nameof(Num2));
                    num1 = value;
                }
            }
        }
        public float? Result
        {
            get { return result; }
            set { result = value; }
        }

        public string Msg
        {
            get { return msg; }
            set { msg = value; }
        }
        #endregion

        public MainWindowViewMode()
        {
            SetCommand();
        }

        public ICommand calculateCommand { get; set; } = null;

        private void SetCommand()
        {
            calculateCommand = new RelayCommand<object>(btnCalcular);
        }

        private void btnCalcular(object sender)
        {
            // Do something here
        }

        public void CalculateNumbers()
        {
            msg = string.Empty;

            // validate inputs:
            float number1;
            if (string.IsNullOrEmpty(num1) || string.IsNullOrWhiteSpace(num1))
            {
                msg = "number 1 is empty or has space";
                return;
            }
            else if (!float.TryParse(num1, out number1))
            {
                msg = "number 1 invalid";
                return;
            }

            float number2;
            if (string.IsNullOrEmpty(num2) || string.IsNullOrWhiteSpace(num2))
            {
                msg = "number 2 is empty or has space";
                return;
            }
            else if (!float.TryParse(num2, out number2))
            {
                msg = "number 2 invalid";
                return;
            }

            switch (operation)
            {
                case "sum":
                    result = number1 + number2;
                    break;
                case "sub":
                    result = number1 - number2;
                    break;
                case "div":
                    result = number1 / number2;
                    break;
                case "mult":
                    result = number1 * number2;
                    break;
            }
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public ViewModelBase() { }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
