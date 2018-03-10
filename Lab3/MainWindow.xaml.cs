using System.Windows;
using Lab3.Exceptions;

namespace Lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel(ShowResultView);
        }

        private void ShowResultView()
        {
            SignUpViewModel data = DataContext as SignUpViewModel;
            if (data != null)
            {
                try
                {
                    Person user = new Person(data.FirstName, data.LastName, data.Email, data.DateOfBirth);
                    string bday = user.IsBirthday ? "Happy Birthday!!!" : "";
                    MessageBox.Show(
                        $"First name: {user.FirstName}\n" +
                        $"Last name: {user.LastName}\n" +
                        $"Email: {user.Email}\n" +
                        $"Date of birth: {user.DateOfBirth}\n" +
                        $"Adult: {user.IsAdult}\n" +
                        $"Our Sign: {user.SunSign}\n" +
                        $"Chinese Sign: {user.ChineseSign}\n" +
                        $"{bday}"
                    );
                }
                catch (IllegalEmailException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (FutureDateException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (PastDateException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
