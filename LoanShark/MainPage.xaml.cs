using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LoanShark.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Input;

namespace LoanShark
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();
        private void OnExpanderToggled(object sender, ExpandedChangedEventArgs e)
        { }
        private void OnExpandButtonClicked(object sender, TappedEventArgs e)
        { }
    }
    partial class MainPageViewModel : ObservableObject
    {
        [RelayCommand]
        private void DeleteLoan(Loan loan)
        {
            Loans.Remove(loan);
        }
        public ObservableCollection<Loan> Loans { get; } = new ObservableCollection<Loan>
        {
            new Loan 
            {
                Name = "Car Loan", OriginalLoanAmount = 15000m, RemainingLoanAmount = 5000m,
                Interest = 5.5m, LoanEndDate = DateTime.Today.AddMonths(24)
            },
            new Loan
            {
                Name = "Personal Loan", OriginalLoanAmount = 8000m, RemainingLoanAmount = 3000m, 
                Interest = 7.2m, LoanEndDate = DateTime.Today.AddMonths(18) 
            },
            new Loan
            {
                Name = "Home Renovation Loan", OriginalLoanAmount = 25000m, RemainingLoanAmount = 12000m,
                Interest = 4.8m, LoanEndDate = DateTime.Today.AddMonths(36) 
            }
        };
    }
    class IsZeroConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (int.TryParse(value?.ToString(), out int count))
            {
                return count == 0;
            }
            throw new FormatException("Expecting int or value parseable to int.");
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
