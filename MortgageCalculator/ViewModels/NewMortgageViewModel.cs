using MortgageCalculator.MVVM;
using System;
using System.Windows.Input;

namespace MortgageCalculator.ViewModels
{
    class NewMortgageViewModel : ObservableObject
    {
        public ICommand CalculateMonthlyPaymentCommand { get { return new RelayCommand(CalculateMonthlyPaymentExec); } }

        private string _principal = "0";
        public string Principal
        {
            get { return _principal; }
            set
            {
                _principal = value;
                OnPropertyChanged(() => Principal);
            }
        }

        private string _apr = "0.04";
        public string APR
        {
            get { return _apr; }
            set
            {
                _apr = value;
                OnPropertyChanged(() => APR);
            }
        }

        private string _loanLength = "30";
        public string LoanLength
        {
            get { return _loanLength; }
            set
            {
                _loanLength = value;
                OnPropertyChanged(() => LoanLength);
            }
        }

        private double _monthlyPayment;
        public double MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                _monthlyPayment = value;
                OnPropertyChanged(() => MonthlyPayment);
            }
        }


        public NewMortgageViewModel()
        {
        }

        public void CalculateMonthlyPaymentExec()
        {
            MonthlyPayment = CalculateMonthlyPayment(Convert.ToDouble(Principal), Convert.ToDouble(APR), Convert.ToInt16(LoanLength));
        }

        public double CalculateMonthlyPayment(double loanAmount, double interestRate, int numberYears)
        {
            // M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1]
            // P = Principal loan amount
            // i = monthly interest rate (yearly / 12)
            // n = length of loan in payments (usually months)

            double monthlyInterestRate = interestRate / 12;
            int numberPayments = numberYears * 12;

            return (loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberPayments))) /
                        (Math.Pow(1 + monthlyInterestRate, numberPayments) - 1);
        }
    }
}
