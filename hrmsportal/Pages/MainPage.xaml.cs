namespace hrmsportal.Pages;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    public class MainPageViewModel : INotifyPropertyChanged
    {
        private bool _isLoginVisible;
        private bool _isSignupVisible;

        public bool IsLoginVisible
        {
            get => _isLoginVisible;
            set
            {
                _isLoginVisible = value;
                OnPropertyChanged(nameof(IsLoginVisible));
            }
        }

        public bool IsSignupVisible
        {
            get => _isSignupVisible;
            set
            {
                _isSignupVisible = value;
                OnPropertyChanged(nameof(IsSignupVisible));
            }
        }

        public ICommand ShowLoginCommand { get; }
        public ICommand ShowSignupCommand { get; }

        public MainPageViewModel()
        {
            // Set initial visibility
            IsLoginVisible = true;
            IsSignupVisible = false;

            ShowLoginCommand = new Command(ShowLogin);
            ShowSignupCommand = new Command(ShowSignup);
        }

        private void ShowLogin()
        {
            IsLoginVisible = true;
            IsSignupVisible = false;
        }

        private void ShowSignup()
        {
            IsLoginVisible = false;
            IsSignupVisible = true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    void Entry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
    }
}


