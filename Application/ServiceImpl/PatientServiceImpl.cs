using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;

namespace Application.ServiceImpl
{
    public class PatientServiceImpl : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientsRepository _patientRepository;

        public PatientServiceImpl(IPatientsRepository patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }

        public void CreatePatient(PatientDto patientDto)
        {
            if (patientDto == null) throw new ArgumentNullException(nameof(patientDto));

            var entity = _mapper.Map<Patients>(patientDto);
            entity.Id = 0;

            _patientRepository.Add(entity);
        }

        public PatientDto GetPatientById(int id)
        {
            var entity = _patientRepository.GetById(id);
            if (entity == null) return null;

            return _mapper.Map<PatientDto>(entity);
        }

        public IList<PatientDto> GetAllPatients()
        {
            var entities = _patientRepository.GetAll();
            return _mapper.Map<IList<PatientDto>>(entities);
        }

        public void UpdatePatient(PatientDto patientDto)
        {
            if (patientDto == null) throw new ArgumentNullException(nameof(patientDto));

            var existingEntity = _patientRepository.GetById(patientDto.Id);
            if (existingEntity == null) throw new ArgumentException("Patient not found.");

            _mapper.Map(patientDto, existingEntity);
            _patientRepository.Update(existingEntity);
        }

        public void DeletePatient(int id)
        {
            var existingEntity = _patientRepository.GetById(id);
            if (existingEntity == null) throw new ArgumentNullException(nameof(id));
            _patientRepository.Delete(id);
        }
    }
}
