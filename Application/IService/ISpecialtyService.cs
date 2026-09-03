using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IService
{
    public interface ISpecialtyService
    {
        void CreateSpecialty(SpecialtyDto specialtyDto);
        SpecialtyDto GetSpecialtyById(int id);
        IList<SpecialtyDto> GetAllSpecialties();
        void UpdateSpecialty(SpecialtyDto specialtyDto);
        void DeleteSpecialty(int id);
    }
}
