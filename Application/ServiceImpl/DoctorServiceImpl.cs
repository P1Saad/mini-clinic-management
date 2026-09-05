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

        private void validattion(DoctorDto doctorDto)
        {
            if (doctorDto == null)
            {
                throw new ArgumentNullException(nameof(doctorDto));
            }
            if (doctorDto.DoctorName == "string" || doctorDto.DoctorName == null)
            {
                throw new ArgumentException("Doctor name is required");
            }
            if (doctorDto.SpecialtyID <0 || doctorDto.SpecialtyID == null)
            {
                throw new ArgumentException("Specialty ID is not valid");
            }
            if (doctorDto.Phone =="string" || doctorDto.Phone == null)
            {
                throw new ArgumentException("Phone number is required");
            }
            if(doctorDto.Phone.Length != 9)
            {
                throw new ArgumentException("Phone number is uncorrect");
            }
            
        }
        public void CreateDoctor(DoctorDto doctorDto)
        {
            validattion(doctorDto);

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
            validattion(doctorDto);

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
