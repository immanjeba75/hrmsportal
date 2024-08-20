namespace hrmsportal.Pages
{
<<<<<<< HEAD
	
	public MainPage()
	{
		InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

<<<<<<< HEAD
    public class MainPageViewModel : INotifyPropertyChanged
=======
    public partial class MainPage : ContentPage
>>>>>>> bf76067 (Added Model, viewModel, Service)
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
<<<<<<< HEAD

    void Entry_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
    {
=======
    private void btnLogin_Clicked(object sender, EventArgs e)
    {
		DisplayAlert("Login", "Login Clicked", "Ok");
>>>>>>> 4896b53 (push)
    }
}


=======
}
>>>>>>> bf76067 (Added Model, viewModel, Service)
