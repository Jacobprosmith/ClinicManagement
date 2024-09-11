using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Appointments
    {
        public Physician Physicianobj { get; set; }
        public DateTime AppointmentTime { get; set; }
        public Patient PatientObj { get; set; }

        // Constructor
        public Appointments(Physician physician, DateTime appointmentTime)
        {
            Physicianobj = physician;
            AppointmentTime = appointmentTime;
            PatientObj = null;
        }
        public Appointments(Physician physician, Patient patient, DateTime appointmentTime)
        {
            Physicianobj = physician;
            AppointmentTime = appointmentTime;
            PatientObj = patient;
        }
    }
}
