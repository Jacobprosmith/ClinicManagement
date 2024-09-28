namespace App.Clinic.Views;
using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Patients");
	}
	private void AddClicked(object sender, EventArgs e)
	{
		var patientToAdd = BindingContext as Patient;
		if (patientToAdd != null)
		{
            PatientServerProxy.Current.AddPatient(patientToAdd);
        }
		Shell.Current.GoToAsync("//Patients");
	}

    private void PatientView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        BindingContext = new Patient();
    }

}