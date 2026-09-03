using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface IDoctorService
    {
        void CreateDoctor(DoctorDto doctorDto);
        DoctorDto GetDoctorById(int id);
        IList<DoctorDto> GetAllDoctors();
        void UpdateDoctor(DoctorDto doctorDto);
        void DeleteDoctor(int id);
    }
}
