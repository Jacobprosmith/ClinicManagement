using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Library.Clinic.Models
{
    public class Appointment
    {
        public override string ToString()
        {
            return Display;
        }
        public string Display
        {
            get
            {
                string patientInfo = PatientObj != null ? $"Patient: {PatientObj.Name} (ID: {PatientObj.PatientId})" : "No patient assigned";
                return $"{Name} Appointment with Dr. {PhysicianObj.Name} (ID: {PhysicianObj.PhysicianId}) " +
                       $"on {AppointmentTime:G} | {patientInfo}";
            }
        }
        public Physician PhysicianObj { get; set; }
        public DateTime AppointmentTime { get; set; }
        public Patient? PatientObj { get; set; }
        public int AppointmentId { get; set; }
        public string? name;

        public string Name
        {
            get
            {
                return name ?? string.Empty;
            }
            set
            {
                name = value;
            }
        }

        public Appointment(Physician physician, Patient patient, DateTime appointmentTime, string name)
        {
            if (physician == null)
            {
                throw new ArgumentNullException(nameof(physician));
            }
            PhysicianObj = physician;
            AppointmentTime = appointmentTime;
            PatientObj = patient;
            Name = name;
        }

        public Appointment()
        {
            PhysicianObj = new Physician { PhysicianId = 0, Name = "Default Physician" }; // Default Physician
            AppointmentTime = DateTime.Now.AddDays(1); // Default to a future date
            PatientObj = null; // This can be null if no patient assigned
            Name = "New Appointment"; // Default name
        }
    }
}
