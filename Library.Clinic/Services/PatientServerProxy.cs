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
            Patients = new List<Patient>
            {
                new Patient{PatientId = 1, Name = "John Doe"}
                ,new Patient{PatientId = 2, Name = "Jane Doe" }
            };
            Console.WriteLine(Patients);
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
        private List<Patient> patients;
        public List<Patient> Patients
        {
            get
            {
                return patients;
            }
            private set
            {
                //if (patients != null)
                //{
                patients = value;
                //}

            }
        }

        public void AddorUpdatePatient(Patient patient)
        {
            bool isAdd = false;
            if (patient.PatientId <= 0)
            {
                patient.PatientId = LastKey + 1;
                isAdd = true;
            }
            if (isAdd)
            {
                Patients.Add(patient);
            }
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