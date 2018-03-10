using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;


namespace Lab3
{
    internal class SignUpViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth = DateTime.Today;
        private string _firstName;
        private string _lastName;
        private string _email;
        private RelayCommand _signUpCommand;
        private readonly Action _signUpSuccessAction;

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand ProceedCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand(SignUpImpl,
                           o => !String.IsNullOrWhiteSpace(_firstName) &&
                                !String.IsNullOrWhiteSpace(_lastName) &&
                                !String.IsNullOrWhiteSpace(_email)));

            }
        }

        public SignUpViewModel(Action signUpSuccessAction)
        {
            _signUpSuccessAction = signUpSuccessAction;
        }

        private async void SignUpImpl(object o)
        {

            await Task.Run((() =>
            {
                //doing something (reading data from db or something like this)
                MessageBox.Show("Your data is is being processed");
                Thread.Sleep(500);
            }));

            _signUpSuccessAction.Invoke();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}