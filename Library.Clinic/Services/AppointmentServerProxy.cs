using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.Models;

namespace Library.Clinic.Services
{
    public class AppointmentServerProxy
    {
        private static object _lock = new object();

        public static AppointmentServerProxy Current
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new AppointmentServerProxy();
                    }
                }
                return instance; 
            }
        }
        private static AppointmentServerProxy? instance;

        private AppointmentServerProxy()
        {
            instance = null;
            Appointments = new List<Appointment>
            {
                new Appointment(
                    
                    new Physician { PhysicianId = 1, Name = "Dr. Smith" },
                    new Patient { PatientId = 1, Name = "Jacob Smith" },
                    new DateTime(2024, 10, 6, 14, 30, 0), "Appointment"  
                    )
                { AppointmentId = 1 }
            };
        }
        public int LastKey
        {
            get
            {
                if (Appointments.Any())
                {
                    return Appointments.Select(x => x.AppointmentId).Max();
                }
                return 0;
            }
        }
        private List<Appointment> appointments;
        public List<Appointment> Appointments
        {
            get
            {
                return appointments;
            }
            private set
            {
                appointments = value;
            }
        }
        public void AddOrUpdateAppointments(Appointment appointments)
        {
            bool isAdd = false;
            if (appointments.AppointmentId <= 0)
            {
                appointments.AppointmentId = LastKey + 1;
                isAdd = true;
            }
            if (isAdd)
            {
                Appointments.Add(appointments);
            }
        }
        public void DeleteAppointment(int id)
        {
            var appointmentToRemove = Appointments.FirstOrDefault(p => p.AppointmentId == id);
            if (appointmentToRemove != null)
            {
                Appointments.Remove(appointmentToRemove);
            }
        }
    }
}
