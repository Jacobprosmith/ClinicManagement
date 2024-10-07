using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.Models;

namespace App.Clinic.ViewModels
{
    public class AppointmentViewModel
    {
        private Appointment? model { get; set; }

        public int AppointmentId
        {
            get
            {
                if (model == null)
                {
                    return -1;
                }

                return model.AppointmentId;
            }
            set
            {
                if (model != null && model.AppointmentId != value)
                {
                    model.AppointmentId = value;
                }
                model.AppointmentId = value;
            }
        }
        public string Name
        {
            get => model?.Name ?? string.Empty;


            set
            {
                if (model != null)
                {
                    model.Name = value;
                }

            }
        }

        public string PhysicianName
        {
            get => model?.PhysicianObj?.Name ?? string.Empty;
            set
            {
                if (model?.PhysicianObj != null)
                {
                    model.PhysicianObj.Name = value;
                }
            }
        }

        public string PatientName
        {
            get => model?.PatientObj?.Name ?? string.Empty;
            set
            {
                if (model?.PatientObj != null)
                {
                    model.PatientObj.Name = value;
                }
            }
        }

        public AppointmentViewModel(Appointment _model)
        {
            model = _model ?? throw new ArgumentNullException(nameof(_model));
        }
    }
}
