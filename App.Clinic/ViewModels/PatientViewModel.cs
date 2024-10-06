using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Clinic.Models;

namespace App.Clinic.ViewModels
{
    public class PatientViewModel
    {
        private Patient? model { get; set; }

        public int PatientId
        {
            get
            {
                if (model == null)
                {
                    return -1;
                }

                return model.PatientId;
            }
            set
            {
                if (model != null && model.PatientId != value)
                {
                    model.PatientId = value;
                }
                model.PatientId = value;
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
        public PatientViewModel() 
        {
            model = new Patient();
        }
        public PatientViewModel(Patient? _model)
        {
            model = _model;
        }
    }
}
