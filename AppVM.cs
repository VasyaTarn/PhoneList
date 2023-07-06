
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Data;
using System.Windows.Input;

namespace PhoneListMVVM
{
    // view model class
    public class AppVM : INotifyPropertyChanged
    {
        private Phone? selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }

        private void AddPhone(object? obj)
        {
            Phone phone = new Phone("Title", "Company", 0);
            Phones.Insert(0, phone);
            SelectedPhone = phone;
        }

        RelayCommand? addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new RelayCommand(AddPhone);
                }
                return addCommand;
            }
        }

        public Phone? SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public AppVM()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone ( "iPhone 14", "Apple", 41499 ),
                new Phone ("Samsung Galaxy S22", "Samsung", 50299),
                new Phone ("Xiaomi 12", "Xiaomi", 25999),
                new Phone ("Samsung Galaxy Fold 4", "Samsung", 79999)
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class RelayCommand : ICommand
    {
        Action<object?> execute;
        Func<object?, bool>? canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
