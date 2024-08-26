using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace hrmsportal.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly AuthService _authService;

        [ObservableProperty]
        private string _loginUsername = "";

        [ObservableProperty]
        private string _loginPassword = "";
        
        [ObservableProperty]
        private bool _isLoginVisible = true;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private bool _isBusy = false;

        [ObservableProperty]
        private ObservableCollection<string> _genderList;

        public MainPageViewModel()
        {
            _authService = new AuthService();
            GenderList = new ObservableCollection<string> { "Male", "Female" };
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


        private const string SuccessTitle = "Success";
        private const string SuccessMessage = "Login successful!";
        private const string ErrorTitle = "Error";
        private const string OkButton = "OK";

        private bool IsAvailable() => !IsBusy;

        [RelayCommand(CanExecute = nameof(IsAvailable))]
        private async Task LoginAsync()
        {
            if (IsBusy)
                return;
            if (string.IsNullOrWhiteSpace(LoginUsername) || string.IsNullOrWhiteSpace(LoginPassword))
            {
                await Shell.Current.DisplayAlert(ErrorTitle, "Username and password are required.", OkButton);
                return;
            }

            IsBusy = true;

            try
            {
                var result = await _authService.LoginAsync(LoginUsername, LoginPassword);

                if (result.Code == 200)
                {
                    await Shell.Current.DisplayAlert(SuccessTitle, SuccessMessage, OkButton);
                    System.Diagnostics.Debug.WriteLine(result.Data);
                    //await Shell.Current.GoToAsync("//DashboardPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert(result.Status, result.Message, OkButton);
                    System.Diagnostics.Debug.WriteLine(result.Message);
                }
            }
            catch (OperationCanceledException)
            {
                await Shell.Current.DisplayAlert(ErrorTitle, "Login was cancelled.", OkButton);
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.DisplayAlert(ErrorTitle, $"Network error: {ex.Message}", OkButton);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred during login: {ex}");
                await Shell.Current.DisplayAlert(ErrorTitle, "An unexpected error occurred. Please try again.", OkButton);
            }
            finally
            {
                IsBusy = false;
            }
        }

        [ObservableProperty]
        private string _registerUsername = "";
        
        [ObservableProperty]
        private string _registerEmail = "";        
        
        [ObservableProperty]
        private int? _registerPhoneNumber = null;

        [ObservableProperty]
        private string _registerPassword = "";
        
        [ObservableProperty]
        private string _registerConfirmPassword = "";

        [ObservableProperty]
        private int? _registerEmployeeId = null;

        [ObservableProperty]
        private string _registerFirstName = "";

        [ObservableProperty]
        private string _registerLastName = "";
        
        [ObservableProperty]
        private string _registerGender = "Male";

        [ObservableProperty]
        private int? _registerBranch = null;
        [RelayCommand]
        partial void OnRegisterGenderChanged(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                System.Diagnostics.Debug.WriteLine($"Selected Gender: {value}");
                //RegisterGender = value;
                // Execute any other logic when gender is selected
            }
        }

        [RelayCommand(CanExecute = nameof(IsAvailable))]
        private async Task RegisterAsync()
        {
            if (IsBusy)
                return;
            if (string.IsNullOrWhiteSpace(RegisterUsername) || string.IsNullOrWhiteSpace(RegisterEmail) || string.IsNullOrWhiteSpace(RegisterPassword) || string.IsNullOrWhiteSpace(RegisterFirstName) || string.IsNullOrWhiteSpace(RegisterLastName) || string.IsNullOrWhiteSpace(RegisterGender))
            {
                await Shell.Current.DisplayAlert(ErrorTitle, "All fields are required.", OkButton);
                return;
            }

            if (RegisterEmployeeId < 0)
            {
                await Shell.Current.DisplayAlert(ErrorTitle, "Employee ID must be greater than 0.", OkButton);
                return;
            }

            if (RegisterPassword != RegisterConfirmPassword)
            {
                await Shell.Current.DisplayAlert(ErrorTitle, "Passwords do not match.", OkButton);
                return;
            }

            IsBusy = true;

            try
            {
                var result = await _authService.RegisterAsync(RegisterUsername, RegisterEmail, RegisterPassword, (int)RegisterEmployeeId, RegisterFirstName, RegisterLastName, RegisterGender, (int)RegisterBranch);

                if (result.Code == 200)
                {
                    await Shell.Current.DisplayAlert(SuccessTitle, SuccessMessage, OkButton);
                    System.Diagnostics.Debug.WriteLine(result.Data);
                    //await Shell.Current.GoToAsync("//DashboardPage");
                }
                else
                {
                    await Shell.Current.DisplayAlert(result.Status, result.Message, OkButton);
                    System.Diagnostics.Debug.WriteLine(result.Message);
                }
            }
            catch (OperationCanceledException)
            {
                await Shell.Current.DisplayAlert(ErrorTitle, "Registration was cancelled.", OkButton);
            }
            catch (HttpRequestException ex)
            {
                await Shell.Current.DisplayAlert(ErrorTitle, $"Network error: {ex.Message}", OkButton);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"An error occurred during registration: {ex}");
                await Shell.Current.DisplayAlert(ErrorTitle, "An unexpected error occurred. Please try again.", OkButton);
            }
        }
    }
}