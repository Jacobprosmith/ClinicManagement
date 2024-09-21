namespace App.Clinic.Views;

public partial class PhysicianManagement : ContentPage
{
	public PhysicianManagement()
	{
		InitializeComponent();
	}
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }
}