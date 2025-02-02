using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LoanShark.Models
{
    class Loan : INotifyPropertyChanged
    {
        public Borrower Borrower { get; } = new Borrower();
        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (!Equals(_isExpanded, value))
                {
                    _isExpanded = value;
                    OnPropertyChanged();
                }
            }
        }
        bool _isExpanded = default;
        public string Name
        {
            get => _name;
            set
            {
                if (!Equals(_name, value))
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        string _name = string.Empty;

        public Decimal OriginalLoanAmount
        {
            get => _OriginalLoanAmount;
            set
            {
                if (!Equals(_OriginalLoanAmount, value))
                {
                    _OriginalLoanAmount = value;
                    OnPropertyChanged();
                }
            }
        }
        Decimal _OriginalLoanAmount = default;

        public Decimal RemainingLoanAmount
        {
            get => _remainingLoanAmount;
            set
            {
                if (!Equals(_remainingLoanAmount, value))
                {
                    _remainingLoanAmount = value;
                    OnPropertyChanged();
                }
            }
        }
        Decimal _remainingLoanAmount = default;

        public Decimal Interest
        {
            get => _interest;
            set
            {
                if (!Equals(_interest, value))
                {
                    _interest = value;
                    OnPropertyChanged();
                }
            }
        }
        Decimal _interest = default;

        public DateTime LoanEndDate
        {
            get => _loanEndDate;
            set
            {
                if (!Equals(_loanEndDate, value))
                {
                    _loanEndDate = value;
                    OnPropertyChanged();
                }
            }
        }
        DateTime _loanEndDate = default;


        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;

    }
    class Borrower
    {
        static int _autoIncrement = 1;
        public string FullName { get; set; } = $"Borrower {_autoIncrement++}";
    }
}
