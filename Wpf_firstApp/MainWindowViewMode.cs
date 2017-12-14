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

        private bool isCheckedSum = false;
        private bool isCheckedSub = false;
        private bool isCheckedDiv = false;
        private bool isCheckedMult = false;
        #endregion

        #region GetterAndSetters
        public bool IsCheckedSum
        {
            get { return isCheckedSum; }
            set
            {
                if (isCheckedSum != value)
                {
                    OnPropertyChanged(nameof(isCheckedSum));
                    isCheckedSum = value;
                }
            }
        }
        public bool IsCheckedSub
        {
            get { return isCheckedSub; }
            set
            {
                if (isCheckedSub != value)
                {
                    OnPropertyChanged(nameof(isCheckedSub));
                    isCheckedSub = value;
                }
            }
        }
        public bool IsCheckedDiv
        {
            get { return isCheckedDiv; }
            set
            {
                if (isCheckedDiv != value)
                {
                    OnPropertyChanged(nameof(isCheckedDiv));
                    isCheckedDiv = value;
                }
            }
        }
        public bool IsCheckedMult
        {
            get { return isCheckedMult; }
            set
            {
                if (isCheckedMult != value)
                {
                    OnPropertyChanged(nameof(isCheckedMult));
                    isCheckedMult = value;
                }
            }
        }
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
                    num2 = value;
                }
            }
        }
        public float? Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    //OnPropertyChanged(nameof(result));
                    result = value;
                    // Como fazer igual o manualQuantity para formatar a string
                }
            }
        }

        public string Msg
        {
            get { return msg; }
            set
            {
                if (msg != value)
                {
                    msg = value;
                    OnPropertyChanged(nameof(msg));                    
                }
            }
        }
        #endregion

        #region Constructor
        public MainWindowViewMode()
        {
            SetCommand();
        }
        #endregion

        public ICommand calculateCommand { get; set; } = null;

        private void SetCommand() //call in class constructor
        {
            calculateCommand = new RelayCommand<object>(btnCalcular);
        }

        private void btnCalcular(object sender) //this guy come of binding
        {
            // Do something here
            Msg = string.Empty;

            // validate inputs:
            float number1;
            if (string.IsNullOrEmpty(num1) || string.IsNullOrWhiteSpace(num1))
            {
                Msg = "number 1 is empty or has space";
                return;
            }
            else if (!float.TryParse(num1, out number1))
            {
                Msg = "number 1 invalid";
                return;
            }

            float number2;
            if (string.IsNullOrEmpty(num2) || string.IsNullOrWhiteSpace(num2))
            {
                Msg = "number 2 is empty or has space";
                return;
            }
            else if (!float.TryParse(num2, out number2))
            {
                Msg = "number 2 invalid";
                return;
            }

            switch (CheckRadionButton())
            {
                case "sum":
                    result = number1 + number2;
                    Msg = result.ToString();
                    break;
                case "sub":
                    result = number1 - number2;
                    Msg = result.ToString();
                    break;
                case "div":
                    result = number1 / number2;
                    Msg = result.ToString();
                    break;
                case "mult":
                    result = number1 * number2;
                    Msg = result.ToString();
                    break;
            }
        }

        private string CheckRadionButton()
        {
            if (IsCheckedSum)
                return "sum";
            else if (IsCheckedSub)
                return "sub";
            else if (IsCheckedDiv)
                return "div";
            else if (isCheckedMult)
                return "mult";
            else
                return string.Empty;
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
