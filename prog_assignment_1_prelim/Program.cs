using Library.Clinic.Models;
using Library.Clinic.Services;
using System.Data;

namespace myApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isContinue = true;
            
            
            List<Patient> patients = new List<Patient>();
            List<Physician> physicians = new List<Physician>();
            Console.WriteLine("THIS PROGRAM IS ASSUMING YOU ARE TRYING TO THE BEST OF YOUR ABILITY TO NOT BREAK IT YET\n");

            do
            {
                Console.WriteLine("Select an Option");
                Console.WriteLine("A. Add Patient");
                Console.WriteLine("P. Add Physician");
                Console.WriteLine("Q. Exit Program");
                Console.WriteLine("L. Display Patient Data");
                Console.WriteLine("D. Delete Patient");
                Console.WriteLine("I. View Physicians");
                Console.WriteLine("C. Create Appointment");
                Console.WriteLine("V. View Appointments");
                //Console.WriteLine("T. avaiable times for a physician");


                string input = Console.ReadLine() ?? string.Empty;


                if (char.TryParse(input, out char choice))
                {
                    switch (choice)
                    {
                        case 'a':
                        case 'A':
                            Console.WriteLine("Input Patient information and click enter after each: Name, Gender, Address, Race ");
                            var name = Console.ReadLine();
                            var gender = Console.ReadLine();
                            var address = Console.ReadLine();
                            var race = Console.ReadLine();
                            Console.WriteLine("Write the birthday in the following format: MM/DD/yyyy");
                            string birthdate = Console.ReadLine();
                            DateTime? birthdateFail = null;
                            if (DateTime.TryParse(birthdate, out DateTime parsedDate))
                            {
                                birthdateFail = parsedDate;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Setting birthday to default value.");
                                birthdateFail = DateTime.MinValue;
                            }
                            Console.WriteLine("Write a perscription for the patient");
                            string perscription = Console.ReadLine();
                            Console.WriteLine("Give a description for the patient");
                            string description = Console.ReadLine();

                            var newPatient = new Patient { Name = name ?? string.Empty, 
                                Address = address ?? string.Empty, Birthday = birthdateFail ?? DateTime.MinValue, 
                                Race = race ?? string.Empty, Gender = gender ?? string.Empty, Diagnoses = perscription ?? string.Empty, 
                                Description = description ?? String.Empty} ;
                            PatientServerProxy.Current.AddPatient(newPatient);
                            
                            break;
                        case 'q':
                        case 'Q':
                            isContinue = false;
                            break;
                        case 'd':
                        case 'D':
                            PatientServerProxy.Patients.ForEach(x => Console.WriteLine($"{x.PatientId}. {x.Name}"));
                            int selectedPatient = int.Parse(Console.ReadLine() ?? "-1");
                            if (selectedPatient < 0)
                            {
                                Console.WriteLine("Invalid Patient Number");
                                break;
                            }
                            PatientServerProxy.Current.DeletePatient(selectedPatient);
                            break;
                        case 'l':
                        case 'L':
                            //PatientServerProxy.Patients.ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
                            PatientServerProxy.Patients.ForEach(x => Console.WriteLine($"{x.PatientId}. {x.Name}, " +
                                $"{x.Gender}, {x.Address}, {x.Race}, {x.Birthday.ToShortDateString()}, " +
                                $"{x.Description}, {x.Diagnoses}"));
                            break;
                        case 'p':
                        case 'P':
                                                    
                            Console.WriteLine("Input Physician information and click enter after each: Name, Specializations, License Number ");
                            var physicianname = Console.ReadLine();
                            var physicianSpecilization = Console.ReadLine();
                            var physicianLicenseNum = Console.ReadLine();
                            Console.WriteLine("Write the Graduation Date in the following format: MM/DD/yyyy");
                            string gradDate = Console.ReadLine();
                            DateTime? gradDateFail = null;
                            if (DateTime.TryParse(gradDate, out DateTime parsedGDate))
                            {
                                gradDateFail = parsedGDate;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Setting Grad date to default value.");
                                gradDateFail = DateTime.MinValue; 
                            }

                            // RIGHT HERE KEEP GOING AND FILL OUT THE PERSONS INFORMATION. BELOW USE A COMMA AND KEEP WRITING THEIR SHIT 
                            var newPhysician = new Physician
                            {
                                Name = physicianname ?? string.Empty,
                                GraduationDate = gradDateFail ?? DateTime.MinValue,
                                LicenseNumber = physicianLicenseNum ?? String.Empty
                            };
                            PhysicianServerProxy.AddPhysician(newPhysician);

                            break;
                        case 'c':
                        case 'C':
                            Console.WriteLine("Enter Patient Name:");
                            var selectedPatientName = Console.ReadLine();
                            var selectedPatient_ = PatientServerProxy.Patients.FirstOrDefault(p => p.Name == selectedPatientName);
                            if (selectedPatient_ == null)
                            {
                                Console.WriteLine("Patient not found.");
                                break;
                            }
                            Console.WriteLine("Enter Physician Name:");
                            var selectedPhysicianName = Console.ReadLine();
                            var selectedPhysician = PhysicianServerProxy.Physicians.FirstOrDefault(p => p.Name == selectedPhysicianName);
                            if (selectedPhysician == null)
                            {
                                Console.WriteLine("Physician not found.");
                                break;
                            }
                            Console.WriteLine("Enter appointment time (MM/DD/YYYY HH:MM): ");
                            string appointmentTimeInput = Console.ReadLine();
                            DateTime appointmentTime;
                            if (DateTime.TryParse(appointmentTimeInput, out appointmentTime))
                            {
                                PhysicianServerProxy.CreateAppointment(selectedPhysician, appointmentTime, selectedPatient_);
                            }
                            else
                            {
                                Console.WriteLine("Invalid date/time format.");
                            }

                            break;
                        case 't':
                        case 'T':
                            Console.WriteLine("Give the Name of the Physician for their available time: ");
                            var availTime = Console.ReadLine();
                            //PhysicianServerProxy.IsAvailable();
                            break;
                        case 'i':
                        case 'I':
                            PhysicianServerProxy.Physicians.ForEach(x => Console.WriteLine($"{x.PhysicianId}. {x.Name}, " +
                                $"{x.Specializations}, {x.LicenseNumber}, {x.GraduationDate.ToShortDateString()}"));
                            break;
                        case 'v':
                        case 'V':
                            Console.WriteLine("Enter Physician Name:");
                            var selectedPhysicianName_ = Console.ReadLine();
                            var selectedPhysician_ = PhysicianServerProxy.Physicians.FirstOrDefault(p => p.Name == selectedPhysicianName_);
                            if (selectedPhysician_ == null)
                            {
                                Console.WriteLine("Physician not found.");
                                break;
                            }

                            Console.WriteLine("Enter Patient Name:");
                            var selectedPatientName_ = Console.ReadLine();
                            selectedPatient_ = PatientServerProxy.Patients.FirstOrDefault(p => p.Name == selectedPatientName_);
                            if (selectedPatient_ == null)
                            {
                                Console.WriteLine("Patient not found.");
                                break;
                            }

                            var appointmentsForPatientAndPhysician = PhysicianServerProxy.GetAppointmentsForPhysicianAndPatient(selectedPhysician_, selectedPatient_);

                            if (appointmentsForPatientAndPhysician.Any())
                            {
                                foreach (var appointment in appointmentsForPatientAndPhysician)
                                {
                                    Console.WriteLine($"Appointment on {appointment.AppointmentTime} with Dr. {appointment.Physicianobj.Name} for patient {appointment.PatientObj.Name}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No appointments found for this patient and physician.");
                            }
                            break;
                    }
                }
            } while (isContinue);
        }
    }
}