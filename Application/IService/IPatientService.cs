using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IPatientService
    {
        void CreatePatient(PatientDto patientDto);
        PatientDto GetPatientById(int id);
        IList<PatientDto> GetAllPatients();
        void UpdatePatient(PatientDto patientDto);
        void DeletePatient(int id);
    }
}
