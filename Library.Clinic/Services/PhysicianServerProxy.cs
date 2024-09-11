using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.Models;


namespace Library.Clinic.Services
{
    public static class PhysicianServerProxy
    {
        private static List<Appointments> allAppointments = new List<Appointments>();
        public static int LastKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Select(x => x.PhysicianId).Max();
                }
                return 0;
            }
        }
        public static List<Physician> Physicians { get; private set; } = new List<Physician>();

        public static void AddPhysician(Physician physician)
        {
            if (physician.PhysicianId <= 0)
            {
                physician.PhysicianId = LastKey + 1;
            }
            Physicians.Add(physician);
        }
        public static void DeletePhysician(int id)
        {
            var physicianToRemove = Physicians.FirstOrDefault(p => p.PhysicianId == id);
            if (physicianToRemove != null)
            {
                Physicians.Remove(physicianToRemove);
            }
        }

        public static bool IsAvailable(List<Appointments> appointments, DateTime dateTime)
        {
            return !appointments.Any(a => a.AppointmentTime == dateTime);
        }

        public static void CreateAppointment(Physician physician, DateTime appointmentTime, Patient patient = null)
        {
            if (!IsAvailable(allAppointments, appointmentTime))
            {
                Console.WriteLine("The selected time slot is already booked.");
                return;
            }

            Appointments newAppointment;

            if (patient != null)
            {
                newAppointment = new Appointments(physician, patient, appointmentTime);
            }
            else
            {
                newAppointment = new Appointments(physician, appointmentTime);
            }

            allAppointments.Add(newAppointment);

            Console.WriteLine($"Appointment created for Dr. {physician.Name} on {appointmentTime}" +
                              $"{(patient != null ? $" with {patient.Name}" : "")}");
        }
        public static List<Appointments> GetAppointmentsForPhysicianAndPatient(Physician physician, Patient patient)
        {
            return allAppointments
                .Where(a => a.Physicianobj.PhysicianId == physician.PhysicianId && a.PatientObj.PatientId == patient.PatientId)
                .ToList();
        }
    }
}