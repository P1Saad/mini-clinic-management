using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            // ربط المستخدمين
            CreateMap<Users, UserDto>().ReverseMap();

            // ربط التخصصات
            CreateMap<Specialties, SpecialtyDto>().ReverseMap();

            // ربط الأطباء
            CreateMap<Doctors, DoctorDto>().ReverseMap();

            // ربط المرضى
            CreateMap<Patients, PatientDto>().ReverseMap();

            // ربط المواعيد
            CreateMap<Appointments, AppointmentDto>().ReverseMap();
        }
    }
}
 