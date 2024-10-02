namespace App.Clinic.Views;
using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;

[QueryProperty(nameof(PatId), "patientId")]

public partial class PatientView : ContentPage
{
	public PatientView()
	{
		InitializeComponent();
	}
	public int PatId { get; set; }
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Patients");
	}
	private void AddClicked(object sender, EventArgs e)
	{
		var patientToAdd = BindingContext as Patient;
		if (patientToAdd != null) 
		{
            PatientServerProxy.Current.AddorUpdatePatient(patientToAdd);
        }
		Shell.Current.GoToAsync("//Patients");
	}

    private void PatientView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        //BindingContext = new Patient();
		if (PatId > 0)
		{
            BindingContext = PatientServerProxy.Current.Patients.FirstOrDefault(p => p.PatientId == PatId); // My patientId from patient class adn then patid from up above
        } else
		{
			BindingContext = new Patient();
		}
    }

}