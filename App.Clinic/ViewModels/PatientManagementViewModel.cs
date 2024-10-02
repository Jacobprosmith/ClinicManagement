using Library.Clinic.Models;
using Library.Clinic.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App.Clinic.ViewModels
{
    public class PatientManagementViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Patient? SelectedPatient { get; set; }
        public ObservableCollection<Patient> Patients
        //public List<Patient> Patients
        {
            get
            {
                return new ObservableCollection<Patient>(PatientServerProxy.Current.Patients);
                //return PatientServerProxy.Current.Patients;

            }
        }
        public void Delete()
        {
            if (SelectedPatient == null)
            {
                return;
            }
            PatientServerProxy.Current.DeletePatient(SelectedPatient.PatientId);
            Refresh();

        }
        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Patients));
        }
    }
}
