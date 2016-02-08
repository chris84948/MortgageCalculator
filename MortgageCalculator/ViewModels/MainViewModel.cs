using MortgageCalculator.MVVM;

namespace MortgageCalculator.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private ObservableObject _newMortgage;
        public ObservableObject NewMortgage
        {
            get { return _newMortgage; }
            set
            {
                _newMortgage = value;
                OnPropertyChanged(() => NewMortgage);
            }
        }

        private ObservableObject _existingMortgage;
        public ObservableObject ExistingMortgage
        {
            get { return _existingMortgage; }
            set
            {
                _existingMortgage = value;
                OnPropertyChanged(() => ExistingMortgage);
            }
        }

        public MainViewModel()
        {
            NewMortgage = new NewMortgageViewModel();
            ExistingMortgage = new ExistingMortgageViewModel();
        }
    }
}
