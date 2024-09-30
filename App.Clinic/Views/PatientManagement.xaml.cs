using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using App.Clinic.ViewModels;

namespace App.Clinic.Views;

public partial class PatientManagement : ContentPage, INotifyPropertyChanged
{
    
	public PatientManagement()
	{
		InitializeComponent();
        BindingContext = new PatientManagementViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void DeletePatient(object sender, EventArgs e)
    {

    }
    private void ViewPatients(object sender, EventArgs e)
    {

    }
    private void AddPatient(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//PatientDetails");
    }
    private void EditPatient(object sender, EventArgs e)
    {

    }
    private void PatientManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as PatientManagementViewModel)?.Refresh();
    }
}