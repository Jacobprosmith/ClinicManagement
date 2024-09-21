namespace App.Clinic.Views;

public partial class AppointmentManagement : ContentPage
{
	public AppointmentManagement()
	{
		InitializeComponent();
	}
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}