namespace App.Clinic.Views;
using Library.Clinic.Models;
using Library.Clinic.Services;
using System.ComponentModel;

[QueryProperty(nameof(AppmtId), "appointmentId")]

public partial class AppointmentView : ContentPage
{
    public AppointmentView()
    {
        InitializeComponent();
    }
    public int AppmtId { get; set; }
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Appointments");
    }
    private void AddClicked(object sender, EventArgs e)
    {
        var appointmentToAdd = BindingContext as Appointment;
        if (appointmentToAdd != null)
        {
            AppointmentServerProxy.Current.AddOrUpdateAppointments(appointmentToAdd);
        }
        Shell.Current.GoToAsync("//Appointments");
    }

    private void AppointmentView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if (AppmtId > 0)
    {
        var appointment = AppointmentServerProxy.Current.Appointments.FirstOrDefault(p => p.AppointmentId == AppmtId);
        if (appointment != null)
        {
            BindingContext = appointment;
        }
    }
    else
    {
        var newAppointment = new Appointment(
            new Physician { PhysicianId = 1, Name = "New Physician" },
            new Patient { PatientId = 1, Name = "New Patient" },
            DateTime.Now.AddDays(1),
            "New Appointment"
        );

        BindingContext = newAppointment;
        }
    }
}