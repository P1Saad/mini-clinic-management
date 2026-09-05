using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;

namespace Application.ServiceImpl
{
    public class AppointmentServiceImpl : IAppointmentService
    {
        private readonly IMapper _mapper;
        private readonly IAppointmentsRepository _appointmentRepository;

        public AppointmentServiceImpl(IAppointmentsRepository appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        private void validation(AppointmentDto appointmentDto)
        {
            if (appointmentDto == null) throw new ArgumentNullException(nameof(appointmentDto));
            if (appointmentDto.AppointmentDate == DateTime.Parse("2026-09-05T16:57:52.135Z") || appointmentDto.AppointmentDate == null)
            {
                throw new ArgumentException("Appointment Date is required");
            }
            if (appointmentDto.PatientID <0 || appointmentDto.PatientID == null)
            {
                throw new ArgumentException("Patient ID is not valid");
            }
            if (appointmentDto.DoctorID <0 || appointmentDto.DoctorID == null)
            {
                throw new ArgumentException("Doctor ID is not valid");
            }
            if (appointmentDto.Status == "string" || appointmentDto.Status == null)
            {
                throw new ArgumentException("Status is required");
            }
        }
        public void CreateAppointment(AppointmentDto appointmentDto)
        {
            validation(appointmentDto);
            var entity = _mapper.Map<Appointments>(appointmentDto);
            entity.Id = 0;

            _appointmentRepository.Add(entity);
        }

        public AppointmentDto GetAppointmentById(int id)
        {
            var entity = _appointmentRepository.GetById(id);
            if (entity == null) return null;

            return _mapper.Map<AppointmentDto>(entity);
        }

        public IList<AppointmentDto> GetAllAppointments()
        {
            var entities = _appointmentRepository.GetAll();
            return _mapper.Map<IList<AppointmentDto>>(entities);
        }

        public void UpdateAppointment(AppointmentDto appointmentDto)
        {
            validation(appointmentDto);

            var existingEntity = _appointmentRepository.GetById(appointmentDto.Id);
            if (existingEntity == null) throw new ArgumentException("Appointment not found.");

            _mapper.Map(appointmentDto, existingEntity);
            _appointmentRepository.Update(existingEntity);
        }

        public void DeleteAppointment(int id)
        {
            var existingEntity = _appointmentRepository.GetById(id);
            if (existingEntity == null) throw new ArgumentNullException(nameof(id));
            _appointmentRepository.Delete(id);
        }
    }
}
