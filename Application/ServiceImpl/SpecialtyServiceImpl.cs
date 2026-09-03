using Application.DTOs;
using Application.IService;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;
using System;
using System.Collections.Generic;

namespace Application.ServiceImpl
{
    public class SpecialtyServiceImpl : ISpecialtyService
    {
        private readonly IMapper _mapper;
        private readonly ISpecialtiesRepository _specialtyRepository;

        public SpecialtyServiceImpl(ISpecialtiesRepository specialtyRepository, IMapper mapper)
        {
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
        }

        public void CreateSpecialty(SpecialtyDto specialtyDto)
        {
            if (specialtyDto == null) throw new ArgumentNullException(nameof(specialtyDto));

            var entity = _mapper.Map<Specialties>(specialtyDto);
            entity.Id = 0;

            _specialtyRepository.Add(entity);
        }

        public SpecialtyDto GetSpecialtyById(int id)
        {
            var entity = _specialtyRepository.GetById(id);
            if (entity == null) return null;

            return _mapper.Map<SpecialtyDto>(entity);
        }

        public IList<SpecialtyDto> GetAllSpecialties()
        {
            var entities = _specialtyRepository.GetAll();
            return _mapper.Map<IList<SpecialtyDto>>(entities);
        }

        public void UpdateSpecialty(SpecialtyDto specialtyDto)
        {
            if (specialtyDto == null) throw new ArgumentNullException(nameof(specialtyDto));

            var existingEntity = _specialtyRepository.GetById(specialtyDto.Id);
            if (existingEntity == null) throw new ArgumentException("Specialty not found.");

            _mapper.Map(specialtyDto, existingEntity);
            _specialtyRepository.Update(existingEntity);
        }

        public void DeleteSpecialty(int id)
        {
            var existingEntity = _specialtyRepository.GetById(id);
            if (existingEntity == null) throw new ArgumentNullException(nameof(id));
            _specialtyRepository.Delete(id);
        }
    }
}
