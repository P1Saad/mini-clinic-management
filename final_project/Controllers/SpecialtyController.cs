using Application.DTOs;
using Application.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using MiniClinicManagement.Controllers.Base;

namespace MiniClinicManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpecialtyController : BaseController
    {
        private readonly ISpecialtyService _specialtyService;

        public SpecialtyController(ILogger<SpecialtyController> logger, ISpecialtyService specialtyService)
            : base(logger)
        {
            _specialtyService = specialtyService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var specialties = _specialtyService.GetAllSpecialties();
                return HandleResponse(specialties);
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to retrieve specialties.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var specialty = _specialtyService.GetSpecialtyById(id);
                if (specialty == null)
                {
                    return NotFound(new { message = "Specialty not found.", success = false });
                }
                return HandleResponse(specialty);
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to retrieve specialty with ID: {id}.");
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] SpecialtyDto specialtyDto)
        {
            try
            {
                if (specialtyDto == null)
                {
                    return BadRequest(new { message = "Invalid specialty data.", success = false });
                }

                _specialtyService.CreateSpecialty(specialtyDto);
                return HandleResponse(new { message = "Specialty created successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to create specialty.");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] SpecialtyDto specialtyDto)
        {
            try
            {
                if (specialtyDto == null)
                {
                    return BadRequest(new { message = "Invalid specialty data.", success = false });
                }

                _specialtyService.UpdateSpecialty(specialtyDto);
                return HandleResponse(new { message = "Specialty updated successfully.", success = true });
            }
            catch (ArgumentException)
            {
                return NotFound(new { message = "Specialty not found to update.", success = false });
            }
            catch (Exception ex)
            {
                return HandleError(ex, "Failed to update specialty.");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _specialtyService.DeleteSpecialty(id);
                return HandleResponse(new { message = "Specialty deleted successfully.", success = true });
            }
            catch (Exception ex)
            {
                return HandleError(ex, $"Failed to delete specialty with ID: {id}.");
            }
        }
    }
}