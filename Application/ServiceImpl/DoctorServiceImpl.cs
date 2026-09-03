using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;

namespace Application.ServiceImpl
{
    public class DoctorServiceImpl : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly IDoctorsRepository _doctorRepository;

        public DoctorServiceImpl(IDoctorsRepository doctorRepository, IMapper mapper)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public void CreateDoctor(DoctorDto doctorDto)
        {
            if (doctorDto == null) throw new ArgumentNullException(nameof(doctorDto));

            var entity = _mapper.Map<Doctors>(doctorDto);
            entity.Id = 0;

            _doctorRepository.Add(entity);
        }

        public DoctorDto GetDoctorById(int id)
        {
            var entity = _doctorRepository.GetById(id);
            if (entity == null) return null;

            return _mapper.Map<DoctorDto>(entity);
        }

        public IList<DoctorDto> GetAllDoctors()
        {
            var entities = _doctorRepository.GetAll();
            return _mapper.Map<IList<DoctorDto>>(entities);
        }

        public void UpdateDoctor(DoctorDto doctorDto)
        {
            if (doctorDto == null) throw new ArgumentNullException(nameof(doctorDto));

            var existingEntity = _doctorRepository.GetById(doctorDto.Id);
            if (existingEntity == null) throw new ArgumentException("Doctor not found.");

            _mapper.Map(doctorDto, existingEntity);
            _doctorRepository.Update(existingEntity);
        }

        public void DeleteDoctor(int id)
        {
            var existingUser = _doctorRepository.GetById(id);
            if (existingUser == null) throw new ArgumentNullException(nameof(id));
            _doctorRepository.Delete(id);
        }
    }
}
