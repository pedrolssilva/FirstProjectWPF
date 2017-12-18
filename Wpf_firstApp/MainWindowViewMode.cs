using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Data;

namespace Wpf_firstApp
{
    public enum CheckOperation
    {
        Sum,
        Sub,
        Div,
        Mult
    }

    public class MainWindowViewMode : ViewModelBase
    {
        #region Attributes
        private string num1;
        private string num2;
        private Nullable<float> result = null;
        private string msg = string.Empty;
        internal string operation = string.Empty;

        //private bool isCheckedSum = false;
        //private bool isCheckedSub = false;
        //private bool isCheckedDiv = false;
        //private bool isCheckedMult = false;

        private ObservableCollection<Result> resultados = new ObservableCollection<Wpf_firstApp.Result>();
        private CheckOperation currentOperation = CheckOperation.Sum;
        #endregion

        #region GetterAndSetters

        public CheckOperation CurrentOperation
        {
            get { return currentOperation; }
            set
            {
                if (currentOperation != value)
                {
                    currentOperation = value;
                    OnPropertyChanged(nameof(currentOperation));
                }
            }
        }

        public ObservableCollection<Result> Results
        {
            get { return resultados; }
            set
            {
                if (resultados != value)
                {
                    OnPropertyChanged(nameof(resultados));
                    resultados = value;
                }
            }
        }
        //public bool IsCheckedSum
        //{
        //    get { return isCheckedSum; }
        //    set
        //    {
        //        if (isCheckedSum != value)
        //        {
        //            OnPropertyChanged(nameof(isCheckedSum));
        //            isCheckedSum = value;
        //        }
        //    }
        //}
        //public bool IsCheckedSub
        //{
        //    get { return isCheckedSub; }
        //    set
        //    {
        //        if (isCheckedSub != value)
        //        {
        //            OnPropertyChanged(nameof(isCheckedSub));
        //            isCheckedSub = value;
        //        }
        //    }
        //}
        //public bool IsCheckedDiv
        //{
        //    get { return isCheckedDiv; }
        //    set
        //    {
        //        if (isCheckedDiv != value)
        //        {
        //            OnPropertyChanged(nameof(isCheckedDiv));
        //            isCheckedDiv = value;
        //        }
        //    }
        //}
        //public bool IsCheckedMult
        //{
        //    get { return isCheckedMult; }
        //    set
        //    {
        //        if (isCheckedMult != value)
        //        {
        //            OnPropertyChanged(nameof(isCheckedMult));
        //            isCheckedMult = value;
        //        }
        //    }
        //}
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
            NumberStyles style = NumberStyles.Float;
            CultureInfo culture = CultureInfo.CurrentCulture; //CreateSpecificCulture("pt-BR");

            #region validate inputs
            float number1;
            if (string.IsNullOrEmpty(num1) || string.IsNullOrWhiteSpace(num1))
            {
                Msg = "number 1 is empty or has space";
                return;
            }
            else if (!float.TryParse(num1, style, culture, out number1))
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
            else if (!float.TryParse(num2, style, culture, out number2))
            {
                Msg = "number 2 invalid";
                return;
            }
            #endregion

            switch (CurrentOperation)                
            {
                case CheckOperation.Sum:
                    result = number1 + number2;
                    Msg = FormatResult(result);
                    resultados.Add(new Result() { Resultoutcome = Msg, Operation = "Sum" });
                    break;
                case CheckOperation.Sub:
                    result = number1 - number2;
                    Msg = FormatResult(result);
                    resultados.Add(new Result() { Resultoutcome = Msg, Operation = "Subtraction" });
                    break;
                case CheckOperation.Div:
                    result = number1 / number2;
                    Msg = FormatResult(result);
                    resultados.Add(new Result() { Resultoutcome = Msg, Operation = "division" });
                    break;
                case CheckOperation.Mult:
                    result = number1 * number2;
                    Msg = FormatResult(result);
                    resultados.Add(new Result() { Resultoutcome = Msg, Operation = "multiplication" });
                    break;
            }
        }
        #region methods
        //private string CheckRadionButton()
        //{
        //    if (IsCheckedSum)
        //        return "sum";
        //    else if (IsCheckedSub)
        //        return "sub";
        //    else if (IsCheckedDiv)
        //        return "div";
        //    else if (isCheckedMult)
        //        return "mult";
        //    else
        //        return string.Empty;
        //}

        public string FormatResult(float? result)
        {
            return string.Format("{0:0.00}", result);
        }
        #endregion

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

    public class Result
    {
        public string Resultoutcome { get; set; }
        public string Operation { get; set; }
    }  
}
