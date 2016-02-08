using MortgageCalculator.MVVM;
using MortgageCalculator.Views;
using System;
using System.Windows.Input;

namespace MortgageCalculator.ViewModels
{
    class ExistingMortgageViewModel : ObservableObject
    {
        public ICommand CalculateMortgageCommand { get { return new RelayCommand(CalculateMortgageExec); } }

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

        private string _apr = "0";
        public string APR
        {
            get { return _apr; }
            set
            {
                _apr = value;
                OnPropertyChanged(() => APR);
            }
        }

        private string _monthlyPayment = "0";
        public string MonthlyPayment
        {
            get { return _monthlyPayment; }
            set
            {
                _monthlyPayment = value;
                OnPropertyChanged(() => MonthlyPayment);
            }
        }

        private string _extraMonthlyPayment = "0";
        public string ExtraMonthlyPayment
        {
            get { return _extraMonthlyPayment; }
            set
            {
                _extraMonthlyPayment = value;
                OnPropertyChanged(() => ExtraMonthlyPayment);
            }
        }

        public ExistingMortgageViewModel()
        {
        }

        private void CalculateMortgageExec()
        {
            var mortgage = new MortgageData(Convert.ToDouble(Principal),
                                            Convert.ToDouble(APR),
                                            Convert.ToDouble(MonthlyPayment));
            mortgage.CalculateMortgageData(Convert.ToDouble(ExtraMonthlyPayment));

            ShowMortgageData(mortgage);
        }

        private void ShowMortgageData(MortgageData mortgage)
        {
            MortgageDataView view = new MortgageDataView();

            view.Principal.Content = mortgage.Principal.ToString("C");
            view.APR.Content = mortgage.APR.ToString("P3");
            view.MonthlyPayment.Content = mortgage.MonthlyPayment.ToString("C");
            view.TotalInterest.Content = mortgage.TotalInterestPaid.ToString("C");
            view.TotalPaid.Content = mortgage.TotalPaid.ToString("C");
            view.PayoffTime.Content = $"{((int)(mortgage.NumberPayments / 12)).ToString()} Years, {(mortgage.NumberPayments % 12).ToString()} Months"; 

            foreach (var payment in mortgage.PaymentSchedule)
                view.PaymentSchedule.Items.Add(payment);

            view.Show();
        }

        public double CalculateMonthlyPayment(double loanAmount, double interestRate, int numberPayments)
        {
            // M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1]
            // P = Principal loan amount
            // i = monthly interest rate (yearly / 12)
            // n = length of loan in payments (usually months)

            double monthlyInterestRate = interestRate / 12;

            return (loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, numberPayments))) / 
                        (Math.Pow(1 + monthlyInterestRate, numberPayments) - 1);
        }
    }
}
