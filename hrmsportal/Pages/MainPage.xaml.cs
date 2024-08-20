namespace hrmsportal.Pages;

public partial class MainPage : ContentPage
{
	
	public MainPage()
	{
		InitializeComponent();
	}

    private void btnLogin_Clicked(object sender, EventArgs e)
    {
		DisplayAlert("Login", "Login Clicked", "Ok");
    }
}


