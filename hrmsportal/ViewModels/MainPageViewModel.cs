using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace hrmsportal.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string _username;

        [ObservableProperty]
        private string _password;
        
        [ObservableProperty]
        private bool _isLoginVisible = true;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private bool _isBusy = false;

        public MainPageViewModel()
        {
            _authService = new AuthService();
        }

        [RelayCommand]
        private void ShowLogin()
        {
            IsLoginVisible = true;
        }
        
        [RelayCommand]
        private void ShowSignup()
        {
            IsLoginVisible = false;
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