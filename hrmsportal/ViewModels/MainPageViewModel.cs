using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace hrmsportal.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string _username;ed

        [ObservableProperty]
        private string _password;
        
        [ObservableProperty]
        private bool _isLoginVisible = true;
        
        [ObservableProperty]
        private bool _isSignupVisible = false;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private bool _isBusy;

        public MainPageViewModel()
        {
            _authService = new AuthService();
        }

        [RelayCommand]
        private void ShowLogin()
        {
            IsLoginVisible = true;
            IsSignupVisible = false;
        }
        
        [RelayCommand]
        private void ShowSignup()
        {
            IsLoginVisible = false;
            IsSignupVisible = true;
        }

        [RelayCommand(CanExecute = nameof(CanLogin))]
        private async Task LoginAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var result = await _authService.LoginAsync(Username, Password);

                if (result.code == 200)
                {
                    await Shell.Current.DisplayAlert("Success", "Login successful!", "OK");
                    // Example: await Shell.Current.GoToAsync("//NextPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert(result.status, result.message, "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", "An error occurred: " + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanLogin() => !IsBusy;
    }
}