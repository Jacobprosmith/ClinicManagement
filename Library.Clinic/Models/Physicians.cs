using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Clinic.Models
{
    public class Physician
    {
        public string Name { get; set; }
        public string Specializations { get; set; }
        public string LicenseNumber { get; set; }
        public int PhysicianId { get; set; }
        public DateTime GraduationDate { get; set; }
        public List<Appointments> Appointments { get; set; }
        public Physician() { 
            Name = string.Empty;
            Specializations = string.Empty;
            LicenseNumber = string.Empty;
            GraduationDate = DateTime.MinValue;
            Appointments = new List<Appointments>();
        }

    }
}
