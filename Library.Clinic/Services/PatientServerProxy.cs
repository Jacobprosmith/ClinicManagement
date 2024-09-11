using Library.Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Services
{
    public class PatientServerProxy
    {
        private static object _lock = new object();
        public static PatientServerProxy Current
        {
            get
            {
                lock(_lock)
                { 
                    if (instance == null)
                    {
                        instance = new PatientServerProxy();
                    }
                }
                return instance;
            }
        }

        private static PatientServerProxy? instance;
        private PatientServerProxy()
        {
            instance = null;
        }
        public int LastKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.PatientId).Max();
                }
                return 0;
            }
        }
        public static List<Patient> Patients { get; private set; } = new List<Patient>();

        public void AddPatient(Patient patient)
        {
            if (patient.PatientId <= 0)
            {
                patient.PatientId = LastKey + 1;
            }
            Patients.Add(patient);
        }
        public void DeletePatient(int id) {
            var patientToRemove = Patients.FirstOrDefault(p => p.PatientId== id);
            if (patientToRemove != null)
            {
                Patients.Remove(patientToRemove);
            }
        }
       
    }
}