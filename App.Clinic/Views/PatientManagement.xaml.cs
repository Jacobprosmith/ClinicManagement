using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace App.Clinic.Views;

public partial class PatientManagement : ContentPage, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public List<Patient> Patients {
        get
        {
            return PatientServerProxy.Current.Patients;
        }
    }
	public PatientManagement()
	{
		InitializeComponent();
        BindingContext = this;
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
}