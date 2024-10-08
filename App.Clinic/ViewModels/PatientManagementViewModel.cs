﻿using Library.Clinic.Models;
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
        public PatientViewModel? SelectedPatient { get; set; }
        public ObservableCollection<PatientViewModel> Patients
        //public List<Patient> Patients
        {
            get
            {
                return new ObservableCollection<PatientViewModel>(
                    PatientServerProxy.Current.Patients
                    .Where(p => p!= null)
                    .Select(p => new PatientViewModel(p)));
   

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
